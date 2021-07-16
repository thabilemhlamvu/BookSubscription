using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSubscription.DataAccess
{
    public class User
    {
        public static Models.User GetUserForSignOn(string emailAddress, string password)
        {
            Models.User item = new Models.User();

            //string connStr = Properties.Settings.Default.ConnectionString;
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    try
            //    {
            //        conn.Open();

            //        string sql = "GetUserForSignOn";

            //        SqlCommand cmd = new SqlCommand(sql, conn);
            //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //        cmd.CommandTimeout = 10000;

            //        cmd.Parameters.AddWithValue("emailAddress", emailAddress);
            //        cmd.Parameters.AddWithValue("password", password);

            //        SqlDataReader rdr = cmd.ExecuteReader();

            //        while (rdr.Read())
            //        {
            //            item.UserId = Convert.ToInt32(rdr["UserId"]);
            //            item.EmailAddress = Convert.ToString(rdr["EmailAddress"]);

            //            break;
            //        }

            //        rdr.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        throw (ex);
            //    }

            //    conn.Close();
            //}

            item.UserId = 1;
            item.emailAddress = "t.s.mhlamvu@gmail.com";
            item.passWord = "P@ssw0rd";

            return item;
        }
        public static Models.User GetUser(string username)
        {
            Models.User item = new Models.User();

            string connStr = Properties.Settings.Default.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string sql = "GetUser";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 10000;

                    cmd.Parameters.AddWithValue("Username", username);

                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        item.UserId = Convert.ToInt32(rdr["UserId"]);
                        item.userName = Convert.ToString(rdr["Username"]);
                        item.passWord = Convert.ToString(rdr["Password"]);
                        item.firstName = Convert.ToString(rdr["FirstName"]);
                        item.lastName = Convert.ToString(rdr["LastName"]);
                        item.emailAddress = Convert.ToString(rdr["EmailAddress"]);


                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }

                conn.Close();
            }

            return item;
        }

        public static void NewUser(Models.User model)
        {
            string connStr = Properties.Settings.Default.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string sql = "NewUser";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 10000;

                    cmd.Parameters.AddWithValue("FirstName", model.firstName);
                    cmd.Parameters.AddWithValue("LastName", model.lastName);
                    cmd.Parameters.AddWithValue("Password", model.passWord);
                    cmd.Parameters.AddWithValue("EmailAddress", model.emailAddress);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }

                conn.Close();
            }
        }
    }
}