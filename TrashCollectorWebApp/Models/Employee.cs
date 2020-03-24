using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorWebApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZIP { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [NotMapped]
        public List<Customer> listOfCustomers { get; set; }
        [NotMapped]
        public List<Customer> listOfCustomersToExclude { get; set; }
        [NotMapped]
        public DayOfWeek DayOfWeekView { get; set; }
        public Employee()
        {

        }
    }
}
