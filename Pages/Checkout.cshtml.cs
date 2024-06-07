using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace KhumaloCraft.Pages
{
    public class CheckoutModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
public class DataHandler
{
    private string connectionString = "Data Source=THANDEKILE\\SQLEXPRESS;Initial Catalog=KhumaloCraft;Integrated Security=True;Trust Server Certificate=True";

    public void InsertAddress(string name, string phoneNumber, string streetAddress, string suburb, string city, string province, string postalCode)
    {
        try
        {
            // Create connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open connection
                connection.Open();

                // Create SQL command with parameters to prevent SQL injection
                string query = "INSERT INTO Address (Name, PhoneNumber, StreetAddress, Suburb, City, Province, PostalCode) VALUES (@Name, @PhoneNumber, @StreetAddress, @Suburb, @City, @Province, @PostalCode)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@StreetAddress", streetAddress);
                    command.Parameters.AddWithValue("@Suburb", suburb);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@Province", province);
                    command.Parameters.AddWithValue("@PostalCode", postalCode);

                    // Execute SQL command
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Address has been saved to the database!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Parse form data from HTTP POST request
            string name = "Nasiphi Velelo";
            string phoneNumber = "0827891236";
            string streetAddress = "123 Main St";
            string suburb = "Mayberry";
            string city = "Alberton";
            string province = "Gauteng";
            string postalCode = "2345";

            // Create instance of DataHandler
            DataHandler dataHandler = new DataHandler();

            // Insert address into the database
            dataHandler.InsertAddress(name, phoneNumber, streetAddress, suburb, city, province, postalCode);
        }

        public class DataHandler
        {
            private string connectionString = "Data Source=THANDEKILE\\SQLEXPRESS;Initial Catalog=KhumaloCraft;Integrated Security=True;Trust Server Certificate=True";

            public void InsertCardDetails(string type, string cardNumber, string cvv, DateTime date, string cardHolderName)
            {
                try
                {
                    // Create connection
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Open connection
                        connection.Open();

                        // Create SQL command with parameters to prevent SQL injection
                        string query = "INSERT INTO CardDetails (Type, CardNumber, CVV, ExpiryDate, CardHolderName) VALUES (@Type, @CardNumber, @CVV, @ExpiryDate, @CardHolderName)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add parameters
                            command.Parameters.AddWithValue("@Type", type);
                            command.Parameters.AddWithValue("@CardNumber", cardNumber);
                            command.Parameters.AddWithValue("@CVV", cvv);
                            command.Parameters.AddWithValue("@ExpiryDate", date);
                            command.Parameters.AddWithValue("@CardHolderName", cardHolderName);

                            // Execute SQL command
                            command.ExecuteNonQuery();
                        }
                    }

                    Console.WriteLine("Card details have been saved to the database!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            internal void InsertAddress(string name, string phoneNumber, string streetAddress, string suburb, string city, string province, string postalCode)
            {
                throw new NotImplementedException();
            }

            class Program
            {
                static void Main(string[] args)
                {
                    // Parse form data from HTTP POST request
                    string type = "VISA";
                    string cardNumber = "1234567890123456";
                    string cvv = "390";
                    DateTime expiryDate = new DateTime(2024, 12, 31);
                    string cardHolderName = "Nasiphi Velelo";

                    // Create instance of DataHandler
                    DataHandler dataHandler = new DataHandler();

                    // Insert card details into the database
                    dataHandler.InsertCardDetails(type, cardNumber, cvv, expiryDate, cardHolderName);
                }
            }
        }
    }
}

