using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace CSharpWithSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>();

            using (var connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                using (var command = new SqlCommand("select * from customers", connection))
                {
                    //SqlDataReader sqlReader = command.ExecuteReader();

                    //while (sqlReader.Read())
                    //{
                    //    var customerID = sqlReader["CustomerID"].ToString();
                    //    var companyName = sqlReader["CompanyName"].ToString();
                    //    var contactName = sqlReader["ContactName"].ToString();
                    //    var contactTitle = sqlReader["ContactTitle"].ToString();
                    //    var city = sqlReader["City"].ToString();

                    //    var customer = new Customer()
                    //    {
                    //        CustomerID = customerID,
                    //        CompanyName = companyName,
                    //        ContactName = contactName,
                    //        ContactTitle = contactTitle,
                    //        City = city
                    //    };

                    //    Console.WriteLine(customer.GetFullName());
                    //    customers.Add(customer);
                    //}

                    var newcustomer = new Customer()
                    {
                        CustomerID = "UZZEC",
                        CompanyName = "UzzeComputers",
                        ContactName = "Uzair",
                        ContactTitle = "Mr",
                        City = "Bedford"
                    };

                    ////Create
                    //string sqlString = $"insert into customers (CustomerID, CompanyName, ContactName, ContactTitle, City) values ('{newcustomer.CustomerID}','{newcustomer.CompanyName}','{newcustomer.ContactName}','{newcustomer.ContactTitle}','{newcustomer.City}')";

                    //using (var command2 = new SqlCommand(sqlString, connection))
                    //{
                    //    int affected = command2.ExecuteNonQuery();
                    //}

                    ////Update
                    //string sqlUpdateString = $"update customers set city = 'Wootton' where customerID = 'UZZEC'";

                    //using (var command3 = new SqlCommand(sqlUpdateString, connection))
                    //{
                    //    int affected = command3.ExecuteNonQuery();
                    //}

                    ////Delete
                    //string sqlDeleteString = $"delete from customers where customerID = 'UZZEC'";

                    //using (var command4 = new SqlCommand(sqlDeleteString, connection))
                    //{
                    //    int affected = command4.ExecuteNonQuery();
                    //}

                    //Adding using stored procedures
                    //using (var updateCustomerCommand = new SqlCommand("UpdateCustomer", connection))
                    //{
                    //    updateCustomerCommand.CommandType = CommandType.StoredProcedure;
                    //    updateCustomerCommand.Parameters.AddWithValue("ID", "UZZEC");
                    //    updateCustomerCommand.Parameters.AddWithValue("NewName", "Umair");
                    //    int affected = updateCustomerCommand.ExecuteNonQuery();
                    //}
                }
            }
        }
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string City { get; set; }

        public string GetFullName() => $"{ContactTitle} - {ContactName}";
    }
}
