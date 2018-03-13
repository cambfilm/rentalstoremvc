using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CamsDVDRentals.Models;

namespace CamsDVDRentals.Data_Access_Layer
{
    public interface IRentalDAL
    {
        IList<Rental> SearchRentals(string title);
        IList<Rental> GetAvailableRentals();
        IList<Rental> GetAllRentals();
        Rental GetRentalById(int rentalId);
        bool CheckOutRental(int rentalId);
        bool ReturnRental(int rentalId);
        IList<Rental> GetTopFiveNewRentals();
        IList<Rental> GetTopFiveMostRented();
        bool CreateNewRental(int rentalId, int userId);
    }
}