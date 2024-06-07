using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace KhumaloCraft.Pages
{
    public class LoginModel : PageModel
    {
        private string connectionString = "Data Source=THANDEKILE\\SQLEXPRESS;Initial Catalog=KhumaloCraft;Integrated Security=True;Trust Server Certificate=True";

        public void OnGet()
        {
           
        }

        public void OnPost(string username, string password)
        {
            InsertLoginData(username, password);
        }

        private void InsertLoginData(string username, string password)
        {
            try
            {
                // Hash password
                string hashedPassword = HashPassword(password);

                // Create connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open connection
                    connection.Open();

                    // Create SQL command with parameters to prevent SQL injection
                    string query = "INSERT INTO Login (Username, Password) VALUES (@Username, @Password)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", hashedPassword);

                        // Execute SQL command
                        command.ExecuteNonQuery();
                    }
                }
              
                Response.Redirect("MyWork");
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                
            }
        }

        private string HashPassword(string password)
        {
            // Create a SHA256 hash from the password
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert bytes to hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
