using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
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

        
        public ActionResult NewRentals()
        {
            IList<Rental> rentals = dal.GetTopFiveNewRentals();

            return PartialView("NewRentals", rentals);
        }

        public ActionResult TopFiveRentals()
        {
            IList<Rental> rentals = dal.GetTopFiveMostRented();

            return PartialView("TopFiveRentals", rentals);
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

        [HttpPost]
        public ActionResult CheckOutRental(int rentalId)
        {
            Rental rental = dal.GetRentalById(rentalId);

            if (rental.IsAvailable)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    dal.CheckOutRental(rentalId);
                    // Call other dal to update rental table

                    scope.Complete();
                }

                return RedirectToAction("CheckOutSuccess");
            }
            else
            {
                return RedirectToAction("RentalUnavailable");
            }
        }

        [HttpPost]
        public ActionResult ReturnRental(int rentalId)
        {
            dal.ReturnRental(rentalId);

            return RedirectToAction("ReturnSuccess");
        }

        public ActionResult CheckOutSuccess()
        {
            return View("CheckOutSuccess");
        }

        public ActionResult RentalUnavailable()
        {
            return View("RentalUnavailable");
        }


    }
}