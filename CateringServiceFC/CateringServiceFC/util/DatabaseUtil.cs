using CateringServiceFC.ds;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CateringServiceFC
{
    class DatabaseUtil
    {
        private  SqlConnection connection;
        private  void connect()
        {
            string connetionString = "Data Source=KAISER;Initial Catalog=CateringService;Integrated Security=True";
            //connetionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=catering;User ID=test;Password=password";

            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.Message);
            }
        }

        public  List<CustomerFoodOrder> getAllCustomerOrder()
        {
            connect();
            string query = "select * from CustomerFoodOrder";
            List<CustomerFoodOrder> ret = new List<CustomerFoodOrder>();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        int customerid = (int)reader["customerid"];
                        DateTime fromdate = (DateTime)reader["fromdate"];
                        DateTime todate = (DateTime)reader["todate"];
                        int starterquantity = (int)reader["starterquantity"];
                        int maincoursequantity = (int)reader["maincoursequantity"];
                        int desertquantity = (int)reader["dessertquantity"];
                        DateTime addedon = (DateTime)reader["addedon"];

                        CustomerFoodOrder order = new CustomerFoodOrder(id, customerid, fromdate, todate, starterquantity, maincoursequantity, desertquantity, addedon);
                        ret.Add(order);
                    }
                }
            }
            connection.Close();
            return ret;
        }


        public  List<Customer> getAllCustomers()
        {
            connect();
            string query = "select * from Customer";
            List<Customer> ret = new List<Customer>();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        String name = (String)reader["name"];
                        DateTime addedon = (DateTime)reader["addedon"];
                        Customer customer
                            = new Customer(id, name, addedon);
                        ret.Add(customer);
                    }
                }
            }
            connection.Close();
            return ret;
        }

        public  List<FoodCategory> getAllFoodCategories()
        {
            connect();
            string query = "select * from FoodCategory";
            List<FoodCategory> ret = new List<FoodCategory>();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        String name = (String)reader["name"];
                        int price = (int)reader["price"];
                        FoodCategory foodCategory
                            = new FoodCategory(id, name, price);
                        ret.Add(foodCategory);
                    }
                }
            }
            connection.Close();
            return ret;
        }


        public  bool addCustomer(int customerId, String name, DateTime addedOn)
        {
            string query = "insert into Customer(id, name, addedon) values (" + customerId + ",'" + name + "','" + addedOn.Year + "-" + addedOn.Month + "-" + addedOn.Day + " 00:00:01');";
            return executeNonQuery(query);
        }

        private  bool executeNonQuery(String query)
        {
            connect();

            SqlCommand command = new SqlCommand(query , connection);
            try
            {
                command.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                MessageBox.Show("Exception: " + e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        private  String dateTimetoStr(DateTime date)
        {
            String ret = "'" + date.Year + "-" + date.Month + "-" + date.Day + " 00:00:01'";
            return ret;
        }

        public  bool addCustomerFoodOrder(int id, int customerId, DateTime fromDate, DateTime toDate, int starterquantity, int maincoursequantity, int dessertquantity, DateTime addedOn)
        {
            string query = "insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values ("
                + id + "," + customerId + "," + dateTimetoStr(fromDate) + "," +
                dateTimetoStr(toDate) + "," + starterquantity + "," + maincoursequantity + "," + dessertquantity + "," + dateTimetoStr(addedOn) + ");";
            return executeNonQuery(query);
        }


    }
}
