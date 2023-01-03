using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;

namespace Testing
{
    //[TestClass]
    public class TestingDatabase
    {
        private string connection = "Server=studmysql01.fhict.local;Uid=dbi486983;Database=dbi486983;Pwd=21092002;";

        //[TestMethod]
        public void IsConnected()
        {
            bool connected;
            try
            {
                using (MySqlConnection con = new(connection))
                {
                    con.Open();
                    connected = con.Ping();
                }
            }
            catch { connected = false; }
            Assert.IsTrue(connected);
        }
    }
}
