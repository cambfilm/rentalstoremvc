using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamsDVDRentals.Data_Access_Layer;
using CamsDVDRentals.Models;

namespace CamsDVDRentals.Controllers
{
    public class RentalController : Controller
    {
        IRentalDAL dal;

        public RentalController(IRentalDAL dal)
        {
            this.dal = dal;
        }
        

        // GET: Rental
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllRentals()
        {
            IList<Rental> rentals = dal.GetAllRentals();

            return View("AllRentals", rentals);
        }

        public ActionResult AvailableRentals()
        {
            IList<Rental> rentals = dal.GetAvailableRentals();

            return View("AvailableRentals", rentals);
        }

        public ActionResult SearchRentalsResults(string title)
        {
            IList<Rental> rentals = dal.SearchRentals(title);

            return View("SearchRentalsResults", rentals);
        }

        public ActionResult RentalDetail(int rentalId)
        {
            var rental = dal.GetRentalById(rentalId);

            return View("RentalDetail", rental);
        }

        public ActionResult CheckOutRental(int rentalId)
        {
            Rental rental = dal.GetRentalById(rentalId);

            if (rental.IsAvailable)
            {
                dal.CheckOutRental(rentalId);
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Unavailable");
            }
        }
    }
}