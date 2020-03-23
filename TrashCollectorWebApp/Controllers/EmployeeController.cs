using System;
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
            ViewBag.ListOfCustomers  = _context.Customers.Where(a => a.ZIP == loggedInUser.ZIP).Where(a => a.DayOfTheWeek == day || a.ExtraPickUpDate == date).Where(a => date < a.TemporarySuspendStart || date > a.TemporarySuspendStart && date > a.TemporarySuspendEnd);
            
            return View(loggedInUser);
        }
        
        // GET: Employee/ViewCustomerLocation
        public ActionResult ViewCustomerLocation(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Employee loggedInUser = _context.Employees.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            Customer foundCustomer = _context.Customers.Where(a => a.CustomerId == id).SingleOrDefault();

            string url = $"https://maps.googleapis.com/maps/api/geocode/xml?address={@loggedInUser.ZIP}&sensor=false&key=AIzaSyBiroI6h2nUiwJzraZhiHpVWoN9Crm1FpA";
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());
            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            XElement locationElement = result.Element("geometry").Element("location");
            XElement lat = locationElement.Element("lat");
            ViewBag.Latitude = lat.Value;            
            XElement lng = locationElement.Element("lng");
            ViewBag.Longitude = lng.Value;

            string urlForCustomer = $"https://maps.googleapis.com/maps/api/geocode/xml?address={foundCustomer.AddressLine1}&sensor=false&key=AIzaSyBiroI6h2nUiwJzraZhiHpVWoN9Crm1FpA";
            WebRequest webRequest = WebRequest.Create(urlForCustomer);
            WebResponse webResponse = request.GetResponse();
            XDocument xDocument = XDocument.Load(webResponse.GetResponseStream());
            XElement resultForCustomer = xDocument.Element("GeocodeResponse").Element("result");
            XElement locationElemenetForCustomer = result.Element("geometry").Element("location");
            XElement latForCustomer = locationElemenetForCustomer.Element("lat");
            ViewBag.LatitudeForCustomer = latForCustomer.Value;
            XElement lngForCustomer = locationElemenetForCustomer.Element("lng");
            ViewBag.LongitudeForCustomer = lngForCustomer.Value;
            return View();
        }

        // POST: Employee/ViewCustomerLocation
        [HttpPost]
        public ActionResult ViewCustomerLocation(int id, Employee employee)
        {
            return View();
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
    public class RootObject
    {
        public string ErrorMessage { get; set; }
        public List<object> results { get; set; }
        public string status { get; set; }
        public double customerLatitude { get; set; }
        public double customerLongitude { get; set; }
    }
}