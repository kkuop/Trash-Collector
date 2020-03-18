using System;
using System.Collections.Generic;
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
        public DayOfWeek PickUpDay { get; set; }
        public DateTime ExtraPickUpDate { get; set; }
        public double Balance { get; set; }
        public DateTime TemporarySuspendStart { get; set; }
        public DateTime TemporarySuspendEnd { get; set; }
        public Customer()
        {

        }
    }
}
