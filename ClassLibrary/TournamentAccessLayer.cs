using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class TournamentAccessLayer
    {
        private Database database;

        public TournamentAccessLayer(Database database)
        {
            this.database = database;
        }

        public List<Tournament> GetAllTournaments() 
        {
            List<Tournament> tournaments = new List<Tournament>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(database.Connection))
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand("select * from tournament", con))
                    {
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Tournament tournament;
                                    int id = (int)dataReader["id"];
                                    string name = dataReader["name"].ToString();
                                    string desc = dataReader["description"].ToString();
                                    string location = dataReader["location"].ToString();
                                    int days = (int)dataReader["durationDays"];
                                    ITournamentSystem tournamentSystem =
                                        dataReader["tournamentSystem"].ToString() == "Single-Elimination" ?
                                        new Single_Elimination() : new Round_Robin();

                                    Sport sport = new Badminton();

                                    BadmintonSchedule? schedule =
                                        new ScheduleAccessLayer(database).GetSchedule(id,tournamentSystem,days);
                                    int maxPlayers = (int)dataReader["maxPlayers"];
                                    int minPlayers = (int)dataReader["minPlayers"];
                                    DateTime dateTime = dataReader.GetDateTime(4);
                                    int registeredPlayers = (int)dataReader["registeredPlayers"];
                                    bool started = (bool)dataReader["started"];

                                    if (schedule != null)
                                    {
                                        tournament = new(id, name, desc, location, days, tournamentSystem, sport, maxPlayers,
                                        minPlayers, dateTime, schedule, registeredPlayers, started);
                                    }
                                    else
                                    {
                                        tournament = new(id, name, desc, location, days, tournamentSystem, sport, maxPlayers,
                                        minPlayers, dateTime, registeredPlayers, started);
                                    }
                                    tournaments.Add(tournament);
                                }
                            }
                        }
                    }
                }        

                return tournaments;
            }
            catch (Exception ex)
            {
                return tournaments;
            }
        } 
        
        public Tournament? GetTournament(int tournamentID)
        {
            Tournament? tournament = null;

            try
            {
                using (MySqlConnection con = new MySqlConnection(database.Connection))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("select * from tournament where id=@id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", tournamentID);
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    int id = (int)dataReader["id"];
                                    string name = dataReader["name"].ToString();
                                    string desc = dataReader["description"].ToString();
                                    string location = dataReader["location"].ToString();
                                    int days = (int)dataReader["durationDays"];
                                    ITournamentSystem tournamentSystem =
                                        dataReader["tournamentSystem"].ToString() == "Single-Elimination" ?
                                        new Single_Elimination() : new Round_Robin();

                                    Sport sport = new Badminton();
                                    BadmintonSchedule? schedule =
                                        new ScheduleAccessLayer(database).GetSchedule(id,tournamentSystem,days);
                                    int maxPlayers = (int)dataReader["maxPlayers"];
                                    int minPlayers = (int)dataReader["minPlayers"];
                                    DateTime dateTime = dataReader.GetDateTime(4);
                                    int registeredPlayers = (int)dataReader["registeredPlayers"];
                                    bool started = (bool)dataReader["started"];

                                    if (schedule != null)
                                    {
                                        tournament = new(id, name, desc, location, days, tournamentSystem, sport, maxPlayers,
                                        minPlayers, dateTime, schedule, registeredPlayers, started);
                                    }
                                    else
                                    {
                                        tournament = new(id, name, desc, location, days, tournamentSystem, sport, maxPlayers,
                                        minPlayers, dateTime, registeredPlayers, started);
                                    }
                                }
                            }
                        }

                    }
                }

                return tournament;        
            }
            catch(Exception ex)
            {
                return tournament;
            }
        }
        
        public void CreateTournament(Tournament tournament)
        {
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();

                    using (MySqlCommand command = new MySqlCommand("insert ignore into tournament values(@id,@name,@desc," +
                        "@location,@date,@days,@sport,@max,@min,@system,@registered,@started)", con))
                    {
                        command.Parameters.AddWithValue("@id", tournament.ID);
                        command.Parameters.AddWithValue("@name", tournament.Name);
                        command.Parameters.AddWithValue("@desc", tournament.Description);
                        command.Parameters.AddWithValue("@location", tournament.Location);
                        command.Parameters.AddWithValue("@date", tournament.StartDate);
                        command.Parameters.AddWithValue("@days", tournament.DurationDays);
                        command.Parameters.AddWithValue("@sport", tournament.Sport.Name);
                        command.Parameters.AddWithValue("@max", tournament.MaxPlayers);
                        command.Parameters.AddWithValue("@min", tournament.MinPlayers);
                        command.Parameters.AddWithValue("@system", tournament.TournamentSystem.Name);
                        command.Parameters.AddWithValue("@registered", tournament.RegisteredPlayers);
                        command.Parameters.AddWithValue("@started", tournament.Started);

                        command.ExecuteNonQuery();
                    }
                }
                
            }
            catch {  }
        }

        public void EditTournament(Tournament tournament)
        {
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();

                    using (MySqlCommand command = new("update tournament set name=@name,description=@desc," +
                        "location=@location,startDate=@date,sport=@sport,durationDays=@days," +
                        "maxPlayers=@max,minPlayers=@min,tournamentSystem=@system," +
                        "registeredPlayers=@registered,started=@started" +
                        " where id=@id", con))
                    {
                        command.Parameters.AddWithValue("@id", tournament.ID);
                        command.Parameters.AddWithValue("@name", tournament.Name);
                        command.Parameters.AddWithValue("@desc", tournament.Description);
                        command.Parameters.AddWithValue("@location", tournament.Location);
                        command.Parameters.AddWithValue("@date", tournament.StartDate);
                        command.Parameters.AddWithValue("@days", tournament.DurationDays);
                        command.Parameters.AddWithValue("@sport", tournament.Sport.Name);
                        command.Parameters.AddWithValue("@max", tournament.MaxPlayers);
                        command.Parameters.AddWithValue("@min", tournament.MinPlayers);
                        command.Parameters.AddWithValue("@system", tournament.TournamentSystem.Name);
                        command.Parameters.AddWithValue("@started", tournament.Started);
                        command.Parameters.AddWithValue("@registered", tournament.RegisteredPlayers);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }
        
        public void DeleteTournament(int tournamentID)
        {
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    using (MySqlCommand command = new("delete from tournament where id=@id", con))
                    {
                        con.Open();
                        command.Parameters.AddWithValue("@id", tournamentID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }
    }
}
