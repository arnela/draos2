using Microsoft.AspNet.Identity;
using Rent_a_car.DAL;
using Rent_a_car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent_a_car.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }

        // GET: Car/Details/5
        public ActionResult Details()
        {
            List<Car> cars = new List<Car>();
            using (RentACarContext context = new RentACarContext())
            {
                cars = context.Cars.ToList();
            }
            return PartialView("Details", cars);
        }

         public ActionResult ViewReservations()
        {
            List<Reservation> reservations = new List<Reservation>();
            List<CarReservation> carReservation = new List<CarReservation>();
            using (RentACarContext context = new RentACarContext())
            {
                reservations = context.Reservations.OrderBy(x=> x.BeginDate).ToList();
                foreach (var reservation in reservations)
                {
                    carReservation.Add(new CarReservation
                    {
                        BeginDate = reservation.BeginDate,
                        EndDate = reservation.EndDate,
                        CarTitle = context.Cars.Where(x => x.ID == reservation.CarId).Select(x=>x.Title).FirstOrDefault(),
                        ReservationID = reservation.ID,
                        NameofCustomer = context.Users.Where(x => x.Id == reservation.UserId).First().FirstName + " " + context.Users.Where(x => x.Id == reservation.UserId).First().LastName,
                        IsActive = reservation.IsActive,
                        IsApproved = reservation.IsApproved
                    });
                }
            }
            return PartialView("ViewReservations", carReservation);
        }

        public ActionResult ViewReservationRequests()
        {
            string userId = User.Identity.GetUserId();
            List<Reservation> reservations = new List<Reservation>();
            List<CarReservation> carReservation = new List<CarReservation>();
            using (RentACarContext context = new RentACarContext())
            {
                reservations = context.Reservations.Where(x=> x.UserId == userId).OrderBy(x => x.BeginDate).ToList();
                foreach (var reservation in reservations)
                {
                    carReservation.Add(new CarReservation
                    {
                        BeginDate = reservation.BeginDate,
                        EndDate = reservation.EndDate,
                        CarTitle = context.Cars.Where(x => x.ID == reservation.CarId).First().Title,
                        ReservationID = reservation.ID,
                        NameofCustomer = context.Users.Where(x => x.Id == reservation.UserId).First().FirstName + " " + context.Users.Where(x => x.Id == reservation.UserId).First().LastName,
                        IsActive = reservation.IsActive,
                        IsApproved = reservation.IsApproved
                    });
                }
            }
            return PartialView("ViewReservationRequests", carReservation);
        }

        

        public ActionResult View()
        {
            List<Car> cars = new List<Car>();
            using (RentACarContext context = new RentACarContext())
            {
                cars = context.Cars.ToList();
            }
            return PartialView("View", cars);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return PartialView("Create");
            //return View();
        }

        public ActionResult ImageUpload()
        {
            return View();
        }

        public ActionResult Reserve()
        {
            List<Car> cars = new List<Car>();
            using (RentACarContext context = new RentACarContext())
            {
                cars = context.Cars.ToList();
            }
            return PartialView("Reserve",cars);
            //return View();
        }


        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(Car model, HttpPostedFileBase file)
        {

           string path =  Server.MapPath("~/CarImages/");

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(path + file.FileName);
                    model.ImagePath =  @"\CarImages\" + file.FileName;
                }
                using (RentACarContext context = new RentACarContext())
                {
                    context.Cars.Add(model);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult Approve(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var reservation = context.Reservations.FirstOrDefault(x => x.ID == id);
                reservation.IsApproved = true;
                reservation.IsActive = false;
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Decline(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var reservation = context.Reservations.FirstOrDefault(x => x.ID == id);
                reservation.IsActive = false;
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }


        // POST: Car/Create
        [HttpPost]
        public ActionResult Reserve(int carId, DateTime beginDate, DateTime endDate)
        {
            //Save image on local path
            if (ModelState.IsValid)
            {
                Reservation model = new Reservation
                {
                    UserId = User.Identity.GetUserId(),
                    CarId = carId,
                    BeginDate = beginDate,
                    EndDate = endDate,
                    IsActive = true,
                    IsApproved = false
                };

                using (RentACarContext context = new RentACarContext())
                {
                    context.Reservations.Add(model); 
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult Save(Car item, string hiddenID, string hiddenImagePath)
        {
            if (ModelState.IsValid)
            {
                item.ID = Convert.ToInt32(hiddenID);
                item.ImagePath = hiddenImagePath;
                using (RentACarContext context = new RentACarContext())
                {
                    var itemTwo = context.Cars.FirstOrDefault(x => x.ID == item.ID);
                    itemTwo.ImagePath = hiddenImagePath;
                    itemTwo.MaxNumberOfPerson = item.MaxNumberOfPerson;
                    itemTwo.Title = item.Title;
                    itemTwo.TypeOfFuel = item.TypeOfFuel;
                    itemTwo.Price = item.Price;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Home");
        }


        // GET: Car/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var car = context.Cars.Where(x => x.ID == id).FirstOrDefault();
                return PartialView("Edit", car);
            }
            
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void CreateImage(Car car, HttpPostedFileBase file)
        {
            string path = @"C:\Users\Arnela\Documents\Visual Studio 2015\Projects\Rent-a-car\Rent-a-car\CarImages\";
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string startupPath = Environment.CurrentDirectory;
                    file.SaveAs(path + file.FileName);
                    car.ImagePath = file.FileName;
                }
            }
          
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            List<Car> cars = new List<Car>();
            using (RentACarContext context = new RentACarContext())
            {
                var car = context.Cars.Where(x => x.ID == id).First();
                TempData["message"] = String.Format("Car {0} was successfully deleted", car.Title);
                context.Cars.Remove(car);
                context.SaveChanges();
                cars = context.Cars.ToList();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Car/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
