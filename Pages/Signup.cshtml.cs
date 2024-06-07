using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System;

namespace KhumaloCraft.Pages
{
    public class SignupModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string connectionString = "Data Source=THANDEKILE\\SQLEXPRESS;Initial Catalog=KhumaloCraft;Integrated Security=True;Trust Server Certificate=True";

            string name = Request.Form["name"];
            string surname = Request.Form["surname"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string confirm_password = Request.Form["confirm_password"];

            // Check if password match
            if (password != confirm_password)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return Page();
            }

            try
            {
                // Create connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();


                    string query = "INSERT INTO Users (Name, Surname, Email, Password) VALUES (@Name, @Surname, @Email, @Password)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Surname", surname);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);

                        // Execute SQL command
                        command.ExecuteNonQuery();
                    }
                }

                return RedirectToPage("/MyWork");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred: " + ex.Message);
                return Page();
            }
        }
    }
}
