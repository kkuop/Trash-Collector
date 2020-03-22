using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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