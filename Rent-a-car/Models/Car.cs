using Rent_a_car.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rent_a_car.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Display(Name = "Image path")]
        public string ImagePath { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Air condition")]
        public bool AirCondition { get; set; }

        [Required]
        [Display(Name = "Maximum number of person")]
        public int MaxNumberOfPerson { get; set; }

        [Required]
        [Display(Name = "Type of fuel")]
        public TypeOfFuel TypeOfFuel { get; set; }

        [Required]
        [Display(Name = "Consumption")]
        public double Consumption { get; set; }

        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }

    }
}