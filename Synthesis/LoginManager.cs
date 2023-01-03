using ClassLibrary;

namespace Synthesis
{
    public class LoginManager
    {
        public LoginManager()
        {

        }

        public bool IsConnected() { bool connected = new Database().IsConnected(); return connected; }

        public Staff? TryLogin(string username, string password) 
        {
            if (!string.IsNullOrEmpty(username))
            {
                if (!string.IsNullOrEmpty(password))
                {
                    string staffErrorMessage = "";
                    string loginErrorMessage = "";
                    StaffAccessLayer staffAccessLayer = new(new Database());
                    Staff? staff = staffAccessLayer.Login(username, password, out loginErrorMessage) ? staffAccessLayer.GetStaff(username, password, out staffErrorMessage) : null;

                    if (staffErrorMessage != "") MessageBox.Show(staffErrorMessage,"Staff error");
                    if (loginErrorMessage != "") MessageBox.Show(loginErrorMessage, "Login error");

                    return staff;
                }
                else
                {
                    MessageBox.Show("Enter a password");
                    return null;
                }
            }
            else
            { 
                MessageBox.Show("Enter a username");
                return null;
            }
        }
    }
}
