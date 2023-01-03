using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class StaffAccessLayer
    {
        private Database database;

        public StaffAccessLayer(Database db)
        {
            database = db;
        }

        public Staff? GetStaff(string username, string password, out string errorMessage)
        {
            errorMessage = "";
            string? userID = "";
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    using(MySqlCommand command = new("Select id from users " +
                        "where username=@username and password=@password", con))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        userID = command.ExecuteScalar().ToString();
                    }           
                }
                return userID == null ? null : new Staff(int.Parse(userID));
            }
            catch (AggregateException) 
            { 
                errorMessage = "Make sure your vpn is connected."; 
                return null; 
            }
            catch (Exception ex) { errorMessage = ex.Message; return null; }
        }

        public bool Login(string username, string password, out string errorMessage)
        {
            errorMessage = "";

            try
            {
                object? staffPassword;

                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    using(MySqlCommand command = new("Select password from users " +
                        "where username=@username and userType='staff'", con))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        staffPassword = command.ExecuteScalar();
                    }                  
                }

                if (staffPassword == null)
                {
                    errorMessage = ("User not found");
                    return false;
                }

                if (staffPassword.ToString() == password)
                    return true;
                else
                {
                    errorMessage = "Wrong password";
                    return false;
                }
            }
            catch (AggregateException)
            {
                errorMessage = ("Make sure your vpn is connected to the database.");
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = (ex.Message);
                return false;
            }
        }
    }
}
