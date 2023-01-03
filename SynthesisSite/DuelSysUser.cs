using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace SynthesisSite
{
    public class DuelSysUser
    {
        public DuelSysUser()
        {

        }

        public int ID { get; set; }

        [Required(ErrorMessage = "You need to type an username")]
        [MinLength(2, ErrorMessage = "Username can't be less than 2 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You need to type a password")]
        [MinLength(4, ErrorMessage = "Password needs at least 4 characters")]
        public string Password { get; set; }

        public string Name { get; set; }
        public int RegisteredTournamentID { get; set; }
        public bool RememberMe { get; set; }
        public string UserType { get; set; }
        public int GetRegisteredTournamentID()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi486983;Database=dbi486983;Pwd=21092002"))
                {
                    conn.Open();
                    MySqlCommand command = new("SELECT tournamentID FROM players where id=@id", conn);
                    command.Parameters.AddWithValue("@id", ID);

                    if (command.ExecuteScalar() == null) return -1;
                    return (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex) { Console.WriteLine("Registered error\n" + ex.Message); return -1; }
        }
        public bool TryLogin()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi486983;Database=dbi486983;Pwd=21092002"))
                {
                    conn.Open();
                    MySqlCommand command = new("SELECT * FROM users where username=@username and password=@password", conn);
                    command.Parameters.AddWithValue("@username", Username);
                    command.Parameters.AddWithValue("@password", Password);

                    MySqlDataReader mySqlDataReader = command.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        ID = mySqlDataReader.GetInt32(0);
                        RegisteredTournamentID = GetRegisteredTournamentID();
                        UserType = mySqlDataReader.GetString(3);
                        Name = mySqlDataReader["name"].ToString();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex) { Console.WriteLine("Login error\n" + ex.Message); return false; }
        }
    }
}
