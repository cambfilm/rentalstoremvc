﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CamsDVDRentals.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace CamsDVDRentals.Data_Access_Layer
{
    public class RentalDAL : IRentalDAL
    {
        private string connectionString;
        const string SQL_ReturnAllAvailableRentals = @"SELECT * FROM movies WHERE available_copies > 0;";
        const string SQL_SearchFilmByTitle = @"SELECT * FROM movies WHERE title LIKE @search;";
        const string SQL_UpdateAvailableCopies = @"UPDATE movies SET available_copies = available_copies - 1 WHERE id = @rentalId;";
        const string SQL_GetRentalById = @"SELECT * FROM movies WHERE id = @rentalId;";

        public RentalDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Rental> GetAvailableRentals()
        {
            List<Rental> rentals = new List<Rental>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_ReturnAllAvailableRentals, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Rental rental = MapRentalFromReader(reader);
                        rentals.Add(rental);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return rentals;
        }

        public IList<Rental> GetAllRentals()
        {
            List<Rental> rentals = new List<Rental>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM movies;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Rental rental = MapRentalFromReader(reader);
                        rentals.Add(rental);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return rentals;
        }


        public IList<Rental> SearchRentals(string title)
        {
            List<Rental> rentals = new List<Rental>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SearchFilmByTitle, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + title + "%");

                    SqlDataReader reader = cmd.ExecuteReader();
                    

                    while (reader.Read())
                    {
                        Rental rental = MapRentalFromReader(reader);
                        rentals.Add(rental);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return rentals;

        }

        public Rental GetRentalById(int rentalId)
        {
            Rental rental = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetRentalById, conn);
                    cmd.Parameters.AddWithValue("@rentalId", rentalId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        rental = MapRentalFromReader(reader);
                    }

                }
            }
            catch (SqlException)
            {
                throw;
            }

            return rental;

        }

        public bool CheckOutRental(int rentalId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_UpdateAvailableCopies, conn);
                    cmd.Parameters.AddWithValue("rentalId", rentalId);

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }

        private Rental MapRentalFromReader(SqlDataReader reader)
        {
            Rental rental = new Rental
            {
                Id = Convert.ToInt32(reader["id"]),
                NumberOfCopies = Convert.ToInt32(reader["num_of_copies"]),
                AvailableCopies = Convert.ToInt32(reader["available_copies"]),
                Title = Convert.ToString(reader["title"]),
                ReleaseDate = Convert.ToDateTime(reader["release_date"])
            };

            return rental;
        }
    }
}