using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamsDVDRentals.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public List<Rental> RentalsCheckedOut { get; set; }
        public bool IsEmployee { get; set; }
    }
}