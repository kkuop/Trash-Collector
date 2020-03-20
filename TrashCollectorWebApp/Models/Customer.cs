using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorWebApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get;set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZIP { get; set; }
        public DayOfWeek DayOfTheWeek { get; set; }
        public DateTime ExtraPickUpDate { get; set; }
        public bool isExtraPickUpDateSet { get; set; }
        public double Balance { get; set; }
        public DateTime TemporarySuspendStart { get; set; }
        public DateTime TemporarySuspendEnd { get; set; }
        public bool isTemporarySuspendSet { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> DaysOfTheWeek { get; set; }
        public Customer()
        {
            isExtraPickUpDateSet = false;
            isTemporarySuspendSet = false;
            DaysOfTheWeek = new List<SelectListItem> { new SelectListItem { Text = "Monday", Value = "1" }, new SelectListItem { Text = "Tuesday", Value = "2" }, new SelectListItem { Text = "Wednesday", Value = "3" }, new SelectListItem { Text = "Thursday", Value = "4" }, new SelectListItem { Text = "Friday", Value = "5" }, new SelectListItem { Text = "Saturday", Value = "6" }, new SelectListItem { Text = "Sunday", Value = "7" } };
        }
    }
}
