using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CamsDVDRentals.Models;

namespace CamsDVDRentals.Data_Access_Layer
{
    public interface IUserDAL
    {
        bool RegisterUser(RegistrationModel model);
    }
}