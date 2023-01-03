using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class Database
    {
        private string connection;
        public string Connection { get => connection; }

        public Database(string connection)
        {
            this.connection = connection;
        }

        public Database()
        {
            connection = "Server=studmysql01.fhict.local;Uid=dbi486983;Database=dbi486983;Pwd=21092002;";
        }

        public bool IsConnected()
        {
            try
            {
                bool result = false;
                using (MySqlConnection con = new(connection))
                {
                    con.Open();
                    result = con.Ping();
                }
                return result;
            }
            catch { return false; }
        }
    }
}