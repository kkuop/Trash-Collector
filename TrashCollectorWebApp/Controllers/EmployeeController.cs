﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrashCollectorWebApp.Data;
using TrashCollectorWebApp.Models;

namespace TrashCollectorWebApp.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context { get; }
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Employee
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var loggedInUser = _context.Employees.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            if (loggedInUser == null)
            {
                return RedirectToAction("Create", "Employee", null);
            }
            //bring in a list of the customers with the same ZIP
            var day = DateTime.Today.DayOfWeek;
            var date = DateTime.Today;
            loggedInUser.listOfCustomers = _context.Customers.Where(a => a.ZIP == loggedInUser.ZIP).Where(a => a.DayOfTheWeek == day || a.ExtraPickUpDate == date).Where(a => date < a.TemporarySuspendStart || date > a.TemporarySuspendStart && date > a.TemporarySuspendEnd).ToList();
            loggedInUser.listOfCustomersToExclude = _context.Customers.Join(_context.PickUps, a => a.CustomerId, b => b.CustomerId, (a, b) => new { Customer = a, PickUp = b }).Where(c => c.PickUp.PickUpDate == DateTime.Today).Where(c => c.Customer.ZIP == loggedInUser.ZIP).Where(c => c.Customer.DayOfTheWeek == day || c.Customer.ExtraPickUpDate == date).Where(c => date < c.Customer.TemporarySuspendStart || date > c.Customer.TemporarySuspendStart && date > c.Customer.TemporarySuspendEnd).Select(c => c.Customer).ToList();
            return View(loggedInUser);
        }

        // POST: Employee/Index
        [HttpPost]
        public ActionResult Index(Employee employee)
        {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var loggedInUser = _context.Employees.Where(a => a.IdentityUserId == userId).SingleOrDefault();
                loggedInUser.DayOfWeekView = employee.DayOfWeekView;
                _context.SaveChanges();
                return RedirectToAction("ViewPickUpsByDay",loggedInUser);
        }
        
        // GET: Employee/ViewCustomerLocation
        public ActionResult ViewCustomerLocation(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Employee loggedInUser = _context.Employees.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            Customer foundCustomer = _context.Customers.Where(a => a.CustomerId == id).SingleOrDefault();
            var address = foundCustomer.AddressLine1;
            address = address.Replace(' ', '+');

            string url = $"https://maps.googleapis.com/maps/api/geocode/xml?address={address},{foundCustomer.City},{foundCustomer.State}&sensor=false&key={ApiKey.Key}";
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());
            try
            {
                XElement result = xdoc.Element("GeocodeResponse").Element("result");
                XElement status = xdoc.Element("GeocodeResponse").Element("status");
                XElement locationElement = result.Element("geometry").Element("location");
                XElement lat = locationElement.Element("lat");
                foundCustomer.Latitude = double.Parse(lat.Value);
                XElement lng = locationElement.Element("lng");
                foundCustomer.Longitude = double.Parse(lng.Value);
                return View(foundCustomer);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Employee/ViewPickUpsByDay
        [HttpGet]
        public ActionResult ViewPickUpsByDay(Employee employee)
        {
            var day = DateTime.Today.DayOfWeek;
            var date = DateTime.Today;
            employee.listOfCustomers = _context.Customers.Where(a => a.ZIP == employee.ZIP).Where(a => a.DayOfTheWeek == employee.DayOfWeekView).ToList();

            if(employee.listOfCustomers.Count >= 1 )
            {
                foreach (var item in employee.listOfCustomers)
                {
                    var address = item.AddressLine1;
                    address = address.Replace(' ', '+');
                    string url = $"https://maps.googleapis.com/maps/api/geocode/xml?address={address},{item.City},{item.State}&sensor=false&key={ApiKey.Key}";
                    WebRequest request = WebRequest.Create(url);
                    WebResponse response = request.GetResponse();
                    XDocument xdoc = XDocument.Load(response.GetResponseStream());
                    try
                    {
                        XElement result = xdoc.Element("GeocodeResponse").Element("result");
                        XElement status = xdoc.Element("GeocodeResponse").Element("status");
                        XElement locationElement = result.Element("geometry").Element("location");
                        XElement lat = locationElement.Element("lat");
                        item.Latitude = double.Parse(lat.Value);
                        XElement lng = locationElement.Element("lng");
                        item.Longitude = double.Parse(lng.Value);                        
                    } catch
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(employee);
        }

        // POST: Employee/ViewPickUpsByDay
        [HttpPost]
        public ActionResult ViewPickUpsByDay(int id, Employee employee)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var loggedInUser = _context.Employees.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            loggedInUser.DayOfWeekView = employee.DayOfWeekView;
            _context.SaveChanges();
            return RedirectToAction("ViewPickUpsByDay",loggedInUser);
        }

        // GET: Employee/ConfirmPickUp
        [HttpGet]
        public ActionResult ConfirmPickUp(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foundCustomer = _context.Customers.Where(a => a.CustomerId == id).SingleOrDefault();
            return View(foundCustomer);
        }

        // POST: Employee/ConfirmPickUp
        [HttpPost]
        public ActionResult ConfirmPickUp(int id, Customer customer)
        {
            try
            {
                PickUp pickUp = new PickUp();
                var foundCustomer = _context.Customers.Where(a => a.CustomerId == id).SingleOrDefault();
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var foundEmployee = _context.Employees.Where(a => a.IdentityUserId == userId).SingleOrDefault();
                foundCustomer.Balance += 4.99;
                pickUp.Customer = foundCustomer;
                pickUp.CustomerId = id;
                pickUp.Employee = foundEmployee;
                pickUp.EmployeeId = foundEmployee.EmployeeId;
                pickUp.PickUpDate = DateTime.Today;
                _context.PickUps.Add(pickUp);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            } catch
            {
                return View();
            }
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                employee.IdentityUserId = userId;
                _context.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}