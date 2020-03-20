using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrashCollectorWebApp.Data;
using TrashCollectorWebApp.Models;

namespace TrashCollectorWebApp.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context { get; }
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var loggedInUser = _context.Customers.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            if(loggedInUser == null)
            {
                return RedirectToAction("Create", "Customer", null);
            }
            return View(loggedInUser);
        }
        // GET: Customer/PayBill
        public ActionResult PayBill(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var loggedInUser = _context.Customers.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            return View(loggedInUser);
        }
        // POST: Customer/PayBill
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PayBill(int id, Customer customer)
        {
            return View();
        }
        // GET: Customer/ChangePickUpDay
        public ActionResult ChangePickUpDay(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var loggedInUser = _context.Customers.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            return View(loggedInUser);
        }
        // POST: Customer/ChangePickUpDay
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePickUpDay(int id, Customer customer)
        {
            try
            {
                Customer foundCustomer = _context.Customers.Where(a => a.CustomerId == customer.CustomerId).SingleOrDefault();
                foundCustomer.DayOfTheWeek = customer.DayOfTheWeek;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: Customer/CancelPickUpDay
        [HttpGet]
        public ActionResult CancelPickUpDay(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var loggedInUser = _context.Customers.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            return View(loggedInUser);
        }
        // POST: Customer/CancelPickUpDay
        [HttpPost]
        public ActionResult CancelPickUpDay(int id, Customer customer)
        {
            try
            {
                Customer foundCustomer = _context.Customers.Where(a => a.CustomerId == id).SingleOrDefault();
                foundCustomer.isExtraPickUpDateSet = false;
                foundCustomer.ExtraPickUpDate = default;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult CancelTempSuspend(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var loggedInUser = _context.Customers.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            return View(loggedInUser);
        }
        [HttpPost]
        public ActionResult CancelTempSuspend(int id, Customer customer)
        {
            try
            {
                Customer foundCustomer = _context.Customers.Where(a => a.CustomerId == id).SingleOrDefault();
                foundCustomer.isTemporarySuspendSet = false;
                foundCustomer.TemporarySuspendStart = default;
                foundCustomer.TemporarySuspendEnd = default;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: Customer/OneTimePickUp
        public ActionResult OneTimePickUp(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var loggedInUser = _context.Customers.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            if(loggedInUser.ExtraPickUpDate < DateTime.Today)
            {
                loggedInUser.isExtraPickUpDateSet = false;
            }
            return View(loggedInUser);
        }
        // POST: Customer/OneTimePickUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OneTimePickUp(int id, Customer customer)
        {
            try
            {
                Customer foundCustomer = _context.Customers.Where(a => a.CustomerId == customer.CustomerId).SingleOrDefault();
                foundCustomer.ExtraPickUpDate = customer.ExtraPickUpDate;
                foundCustomer.isExtraPickUpDateSet = true;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: Customer/TemporarySuspend
        public ActionResult TemporarySuspend(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var loggedInUser = _context.Customers.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            if (loggedInUser.TemporarySuspendEnd < DateTime.Today)
            {
                loggedInUser.isTemporarySuspendSet = false;
            }
            return View(loggedInUser);
        }
        // POST: Customer/TemporarySuspend
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TemporarySuspend(int id, Customer customer)
        {
            try
            {
                Customer foundCustomer = _context.Customers.Where(a => a.CustomerId == customer.CustomerId).SingleOrDefault();
                foundCustomer.TemporarySuspendStart = customer.TemporarySuspendStart;
                foundCustomer.TemporarySuspendEnd = customer.TemporarySuspendEnd;
                foundCustomer.isTemporarySuspendSet = true;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Customer customer = new Customer()
            {
            };
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here

                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                customer.IdentityUserId = userId;
                _context.Add(customer);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);            
            var foundCustomer = _context.Customers.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            return View(foundCustomer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                Customer foundCustomer = _context.Customers.Where(a => a.CustomerId == customer.CustomerId).SingleOrDefault();
                foundCustomer.FirstName = customer.FirstName;
                foundCustomer.LastName = customer.LastName;
                foundCustomer.AddressLine1 = customer.AddressLine1;
                foundCustomer.City = customer.City;
                foundCustomer.State = customer.State;
                foundCustomer.ZIP = customer.ZIP;
                foundCustomer.DayOfTheWeek = customer.DayOfTheWeek;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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