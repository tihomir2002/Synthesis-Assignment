using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class ScheduleAccessLayer
    {
        private Database database;
        public ScheduleAccessLayer(Database database)
        {
            this.database = database;
        }

        public List<BadmintonSchedule> GetAllSchedules()
        {
            List<BadmintonSchedule> schedules = new List<BadmintonSchedule>();
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();

                    using(MySqlCommand command = new("select * from schedule", con))
                    {
                        using(MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Tournament? tournament = new TournamentAccessLayer(database).GetTournament((int)reader["tournamentID"]);
                                    if (tournament == null) continue;

                                    List<Game>? games = new GamesAccessLayer(database).GetAllTournamentGames(tournament.ID);
                                    if (games == null) continue;

                                    schedules.Add(new BadmintonSchedule(tournament.ID,tournament.TournamentSystem,
                                        tournament.DurationDays, games));
                                }
                            }
                        }
                    }                    
               
                }

                return schedules;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return schedules; }
        }

        public BadmintonSchedule? GetSchedule(int tournamentID, ITournamentSystem tournamentSystem, int durationDays)
        {
            BadmintonSchedule? schedule = null;
            List<Game> games = new();

            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();

                    using (MySqlCommand command = new("select * from schedule where tournamentID=@id", con))
                    {
                        command.Parameters.AddWithValue("@id", tournamentID);
                        using (MySqlDataReader dataReader = command.ExecuteReader())
                        {

                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    //List<Game>? games = new GamesAccessLayer(database).GetAllTournamentGames(tournamentID);
                                    //if (games == null) continue;
                                    //schedule = new(tournamentID,tournamentSystem,durationDays, games);
                                    //Game game = new Game(tournamentID,)
                                    PlayersAccessLayer playersAccessLayer = new(database);
                                    Player playerOne = playersAccessLayer.GetPlayer((int)dataReader["playerOneID"]);
                                    Player playerTwo = playersAccessLayer.GetPlayer((int)dataReader["playerTwoID"]);

                                    List<Player> players = new() { playerOne, playerTwo };
                                    games.Add(new((int)dataReader["gameID"],tournamentID,players,
                                        dataReader["result"].ToString(),(bool)dataReader["finished"], 
                                        (bool)dataReader["twoPointsForWin"]));
                                }
                            }
                        }
                    }
                }
                schedule = new(tournamentID, tournamentSystem, durationDays, games);

                return schedule;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return schedule; }
        }

        public void AddSchedule(BadmintonSchedule schedule)
        {
            try
            {
                using(MySqlConnection con = new(database.Connection))
                {
                    using(MySqlCommand command = new("insert ignore into schedule(tournamentID,result,finished,twoPointsForWin,playerOneID,playerTwoID) values" +
                        "(@tournamentID,@result,@finished,@points,@playerID,@playerID1)", con))
                    {
                        con.Open();
                        foreach (Game game in schedule.Games)
                        {
                            command.Parameters.AddWithValue("@gameID", game.ID);
                            command.Parameters.AddWithValue("@result", game.Result);
                            command.Parameters.AddWithValue("@finished", game.Finished);
                            command.Parameters.AddWithValue("@tournamentID", schedule.TournamentID);
                            command.Parameters.AddWithValue("@points", game.TwoPointsForWin);
                            command.Parameters.AddWithValue("@playerID", game.Players.Keys.ElementAt(0));
                            command.Parameters.AddWithValue("@playerID1", game.Players.Keys.ElementAt(1));

                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                    }

                    con.Close();
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void UpdateSchedule(BadmintonSchedule schedule)
        {
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    using(MySqlCommand command = new("update schedule " +
                        "set tournamentID=@tournamentID,result=@result," +
                        "finished = @finished,twoPointsForWin=@points  " +
                        "where gameID=@gameID", con))
                    {
                        con.Open();

                        foreach (Game game in schedule.Games)
                        {
                            command.Parameters.AddWithValue("@gameID", game.ID);
                            command.Parameters.AddWithValue("@result", game.Result);
                            command.Parameters.AddWithValue("@finished", game.Finished);
                            command.Parameters.AddWithValue("@tournamentID", schedule.TournamentID);
                            command.Parameters.AddWithValue("@points", game.TwoPointsForWin);

                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void DeleteSchedule(int tournamentID)
        {
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    using (MySqlCommand command = new("delete from schedule where tournamentID=@id", con))
                    {
                        con.Open();
                        command.Parameters.AddWithValue("@id", tournamentID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
