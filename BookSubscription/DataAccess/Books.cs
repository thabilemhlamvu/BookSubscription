using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace BookSubscription.DataAccess
{
    public class Books
    {
        public static List<Models.Book> GetBookList(string username,string password)
        {
           List<Models.Book> list = new List<Models.Book>();

            string connStr = Properties.Settings.Default.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string sql = "GetBooks";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 10000;

                    // use this if you need to send parameters to the sp
                    cmd.Parameters.AddWithValue("Username", username);
                    cmd.Parameters.AddWithValue("Username", password);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Models.Book items = new Models.Book();

                        items.Name = Convert.ToString(rdr["Name"]);
                        items.Text = Convert.ToString(rdr["Text"]);
                        items.Price = Convert.ToDouble(rdr["Price"]);
                        if (rdr["SubscriptionStartDate"] != DBNull.Value)
                            items.SubscriptionStartDate = Convert.ToDateTime(rdr["SubscriptionStartDate"]);

                        if (rdr["SubscriptionEndDate"] != DBNull.Value)
                            items.SubscriptionEndDate = Convert.ToDateTime(rdr["SubscriptionEndDate"]);

                        items.SubscriptionType = Convert.ToString(rdr["SubscriptionType"]);

                       // break;

                        list.Add(items);
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }

                conn.Close();
            }

            //Models.Book item = new Models.Book();

            //item.Name = "test 1";
            //item.Description = "test 1 desc";
            //item.Price = 20.90;

            //list.Add(item);

            return list;
        }
        public static void SaveBook(Models.Book item)
        {
            string connStr = Properties.Settings.Default.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string sql = "SaveBook";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 10000;

                    cmd.Parameters.AddWithValue("Name", item.Name);
                    cmd.Parameters.AddWithValue("Text", item.Text);
                    cmd.Parameters.AddWithValue("SubscriptionType", item.SubscriptionType);
                    cmd.Parameters.AddWithValue("Price", item.Price);
                    cmd.Parameters.AddWithValue("SubscriptionEndDate", item.SubscriptionStartDate);
                    cmd.Parameters.AddWithValue("SubscriptionEndDate", item.SubscriptionEndDate);

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