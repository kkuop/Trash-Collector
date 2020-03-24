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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get;set; }
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZIP { get; set; }
        [Display(Name = "Pick Up Day")]
        public DayOfWeek DayOfTheWeek { get; set; }
        [Display(Name = "Extra Pick Up Date")]
        public DateTime ExtraPickUpDate { get; set; }
        public bool isExtraPickUpDateSet { get; set; }
        public double Balance { get; set; }
        [Display(Name = "Temporary Suspend Start Date")]
        public DateTime TemporarySuspendStart { get; set; }
        [Display(Name = "Temporary Suspend End Date")]
        public DateTime TemporarySuspendEnd { get; set; }
        public bool isTemporarySuspendSet { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> DaysOfTheWeek { get; set; }
        [NotMapped]
        public double Latitude { get; set; }
        [NotMapped]
        public double Longitude { get; set; }
        public Customer()
        {
            isExtraPickUpDateSet = false;
            isTemporarySuspendSet = false;
            DaysOfTheWeek = new List<SelectListItem> { new SelectListItem { Text = "Monday", Value = "1" }, new SelectListItem { Text = "Tuesday", Value = "2" }, new SelectListItem { Text = "Wednesday", Value = "3" }, new SelectListItem { Text = "Thursday", Value = "4" }, new SelectListItem { Text = "Friday", Value = "5" }, new SelectListItem { Text = "Saturday", Value = "6" }, new SelectListItem { Text = "Sunday", Value = "7" } };
        }
    }
}
