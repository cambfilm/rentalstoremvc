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

        //public List<Rental> GetRentalsCheckedOut(UserModel model)
        //{
        //    try
        //    {
        //        using(SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand cmd = new SqlCommand();
        //        }
        //    }
        //    catch (SqlException)
        //    {
        //        throw;
        //    }
        //}
    }
}