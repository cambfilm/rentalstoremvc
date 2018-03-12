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
    }
}