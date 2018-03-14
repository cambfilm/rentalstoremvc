using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CamsDVDRentals.Models;
using System.Configuration;
using System.Data.SqlClient;
namespace CamsDVDRentals.Data_Access_Layer
{
    public class UserDAL : IUserDAL
    {
        private string connectionString;

        const string SQL_InsertRegistrationIntoUserTable = @"INSERT INTO [user] VALUES (@email, @password, 1, @isEmployee);";
        const string SQL_CheckLogin = @"SELECT * FROM [user] WHERE email = @email AND password = @password;";
        const string SQL_CheckIfEmployee = @"SELECT employee_account FROM [user] WHERE id = @userId;";
        const string SQL_GetRentalsFromUserId = @"SELECT * FROM user_rental JOIN movies on user_rental.movie_id = movies.id WHERE user_id = @userId AND return_date IS NULL;";

        public UserDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool RegisterUser(RegistrationModel model)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_InsertRegistrationIntoUserTable, conn);
                    cmd.Parameters.AddWithValue("@email", model.Email);
                    cmd.Parameters.AddWithValue("@password", model.Password);
                    cmd.Parameters.AddWithValue("@isEmployee", model.IsEmployee);

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }


        public int CheckLoginCredentials(LoginModel login)
        {
            int userId = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_CheckLogin, conn);
                    cmd.Parameters.AddWithValue("@email", login.Email);
                    cmd.Parameters.AddWithValue("@password", login.Password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        userId = Convert.ToInt32(reader["id"]);
                    }

                    return userId;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool CheckIfEmployeeByUserId(int userId)
        {
            bool isEmployee = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_CheckIfEmployee, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
       

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        isEmployee = Convert.ToBoolean(reader["employee_account"]);
                    }

                    return isEmployee;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public List<Rental> GetRentalsCheckedOut(int userId)
        {
            List<Rental> rentals = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetRentalsFromUserId, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Rental rental = new Rental
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Title = Convert.ToString(reader["title"]),
                            CheckOutDate = Convert.ToDateTime(reader["checkout_date"]),
                            ReturnDate = Convert.ToDateTime(reader["return_date"])
                        };

                        rentals.Add(rental);
                    }

                    return rentals;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}