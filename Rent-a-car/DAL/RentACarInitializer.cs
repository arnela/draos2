using Rent_a_car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent_a_car.DAL
{
    public class RentACarInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RentACarContext>
    {
        protected override void Seed(RentACarContext context)
        {
            var cars = new List<Car>
            {
                new Car{Title = "Chevrolet Aveo", AirCondition = true, ImagePath =  @"C:\Users\Arnela\Documents\Visual Studio 2015\Projects\Rent-a-car\Rent-a-car\CarImages\aveo2.jpg", MaxNumberOfPerson = 4, TypeOfFuel = Models.Enums.TypeOfFuel.Benzin, Consumption = 6},
                new Car{Title = "Chevrolet Cruze", AirCondition = true, ImagePath =  @"C:\Users\Arnela\Documents\Visual Studio 2015\Projects\Rent-a-car\Rent-a-car\CarImages\cruze1.jpg", MaxNumberOfPerson = 4, TypeOfFuel = Models.Enums.TypeOfFuel.Benzin, Consumption = 8},
                new Car{Title = "Skoda Octavia", AirCondition = true, ImagePath =  @"C:\Users\Arnela\Documents\Visual Studio 2015\Projects\Rent-a-car\Rent-a-car\CarImages\octavia1.jpg", MaxNumberOfPerson = 4, TypeOfFuel = Models.Enums.TypeOfFuel.Dizel, Consumption = 10},
                new Car{Title = "Mercedes E class", AirCondition = true, ImagePath =  @"C:\Users\Arnela\Documents\Visual Studio 2015\Projects\Rent-a-car\Rent-a-car\CarImages\eclass.jpg", MaxNumberOfPerson = 4, TypeOfFuel = Models.Enums.TypeOfFuel.Dizel, Consumption = 12}
            };
            cars.ForEach(c => context.Cars.Add(c));
            context.SaveChanges();          

        }
    }  
}
