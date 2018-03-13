using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamsDVDRentals.Data_Access_Layer;
using CamsDVDRentals.Models;

namespace CamsDVDRentals.Controllers
{
    public class UserController : Controller
    {

        IUserDAL dal;

        public UserController(IUserDAL dal)
        {
            this.dal = dal;
        }

        // GET: User

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            bool wasSuccessful = dal.RegisterUser(model);

            if (wasSuccessful)
            {
                return RedirectToAction("RegistrationSuccess");
            }
            else
            {
                return RedirectToAction("RegistrationFailure");
            }
        }

        public ActionResult RegistrationSuccess()
        {
            return View();
        }

        public ActionResult RegistrationFailure()
        {
            return View();
        }

        public ActionResult RentalsCheckedOut(UserModel model)
        {
            return View("RentalsCheckedOut", model.RentalsCheckedOut);
        }


        

        public ActionResult Login(UserModel model)
        {
            if (!model.IsEmployee)
            {
                return View("UserPage", model);
            }
            else
            {
                return View("Index", "Employee", model);
            }
            
        }
    }
}