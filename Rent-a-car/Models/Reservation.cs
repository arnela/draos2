using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent_a_car.Models
{
    public class Reservation
    {
        public int ID { get; set; }

        public int CarId { get; set; }

        public string UserId { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsApproved { get; set; }

        public bool IsActive { get; set; }
    }
}