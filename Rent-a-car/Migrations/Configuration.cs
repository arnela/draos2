namespace Rent_a_car.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rent_a_car.DAL.RentACarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Rent_a_car.DAL.RentACarContext context)
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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
