using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent_a_car.Models
{
    public class CarReservation
    {
        public string CarTitle { get; set; }

        public string NameofCustomer { get; set; }

        public int ReservationID { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsApproved { get; set; }

        public decimal Price { get; set; }
    }
}