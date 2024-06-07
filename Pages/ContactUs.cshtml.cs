using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;

namespace KhumaloCraft.Pages
{
    public class ContactUsModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(string name, string surname, string email, string message)
        {
            
            string connectionString = "Data Source=THANDEKILE\\SQLEXPRESS;Initial Catalog=KhumaloCraft;Integrated Security=True;Trust Server Certificate=True";

            try
            {
 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    connection.Open();

                   
                    string query = "INSERT INTO ContactUs (Name, Surname, Email, Message) VALUES (@Name, @Surname, @Email, @Message)";

                    // Create command with parameters to prevent SQL injection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Surname", surname);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Message", message);
                        

                        // Execute SQL command
                        command.ExecuteNonQuery();
                    }
                }

                // Display success message
                TempData["Message"] = "Message has been sent!";
            }
            catch (Exception ex)
            {
                // Display error message
                TempData["Message"] = "An error occurred: " + ex.Message;
            }

            // same page
            return RedirectToPage();
        }

    }
}
