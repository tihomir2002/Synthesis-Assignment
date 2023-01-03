using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using MySql.Data.MySqlClient;

namespace Testing
{
    //[TestClass]
    public class TestingStaffAccessLayer
    {
        //[TestMethod]
        public void GetStaff()
        {
            Staff? staff;
            string username = "staff";
            string password = "0000";

            try
            {
                using (MySqlConnection con = new(new Database().Connection))
                {
                    con.Open();
                    MySqlCommand command = new("Select id from users " +
                        "where username=@username and password=@password", con);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    string? userID = command.ExecuteScalar().ToString();
                    staff = userID == null ? null : new Staff(int.Parse(userID));
                }
            }
            catch { staff = null; }
            Assert.IsNotNull(staff, null);
        }

        //[TestMethod]
        public void Login()
        {
            bool logged;
            string username = "staff";
            string password = "0000";

            try
            {
                using (MySqlConnection con = new(new Database().Connection))
                {
                    con.Open();
                    MySqlCommand command = new("Select password from users " +
                        "where username=@username and userType='staff'", con);
                    command.Parameters.AddWithValue("@username", username);

                    object? staffPassword = command.ExecuteScalar();

                    if (staffPassword == null) logged = false;

                    if (staffPassword.ToString() == password) logged = true;
                    else logged = false;
                }
            }
            catch{ logged = false; }

            Assert.IsTrue(logged);
        }
    }
}