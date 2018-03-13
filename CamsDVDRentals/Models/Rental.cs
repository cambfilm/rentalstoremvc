using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamsDVDRentals.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public int NumberOfCopies { get; set; }

        public int AvailableCopies { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public bool IsAvailable { get => AvailableCopies > 0; }

        public int TimesRented { get; set; }

        public string Availabilty
        {
            get
            {
                if (AvailableCopies == 0)
                {
                    return "No available copies. Sorry!";
                }
                else if (AvailableCopies < 3)
                {
                    return "Only " + AvailableCopies + " left";
                }

                return "";
            }
        }
    }
}