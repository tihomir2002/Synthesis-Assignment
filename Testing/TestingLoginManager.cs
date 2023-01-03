using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace Testing
{
    //[TestClass]
    public class TestingLoginManager
    {
        //[TestMethod]
        public void TryLogin()
        {
            Staff? staff;
            string loginErrorMessage = "";
            string staffErrorMessage = "";
            string username = "staff";
            string password = "0000";

            if (!string.IsNullOrEmpty(username))
            {
                if (!string.IsNullOrEmpty(password))
                {
                    StaffAccessLayer staffAccessLayer = new(new Database());
                    staff = staffAccessLayer.Login(username, password,out loginErrorMessage) ? staffAccessLayer.GetStaff(username, password,out staffErrorMessage) : null;
                }
                else { staff = null; }
            }
            else{ staff = null; }

            Assert.AreNotEqual(staff, null);
        }
    }
}
