using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class GamesAccessLayer
    {
        private Database database;
        public GamesAccessLayer(Database database)
        {
            this.database = database;
        }

        public List<Game> GetAllTournamentGames(int tournamentID)
        {
            try
            {
                List<Game> games = new List<Game>();
                List<Player> players = new List<Player>();

                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();

                    using (MySqlCommand command = new("select * from players where tournamentID=@id", con))
                    {
                        command.Parameters.AddWithValue("@id", tournamentID);

                        using (MySqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    int id = (int)dataReader["id"];

                                    if(dataReader["gameID"] is DBNull)
                                    {
                                        players.Add(new Player(id, dataReader.GetString(1),tournamentID));                              
                                    }
                                    else
                                    {
                                        players.Add(new Player(id, dataReader.GetString(1),
                                        tournamentID, (int)dataReader["gameID"],
                                        dataReader.GetInt32(2), dataReader.GetInt32(4), dataReader.GetInt32(5),
                                        dataReader.GetInt32(3)));
                                    }
                                }
                            }
                        }
                    }
                    using (MySqlCommand command = new("select * from schedule where tournamentID=@id", con))
                    {
                        command.Parameters.AddWithValue("@id", tournamentID);

                        using (MySqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    games.Add(new((int)dataReader["gameID"], (int)dataReader["tournamentID"], players, dataReader["result"].ToString(), (bool)dataReader["finished"], (bool)dataReader["twoPointsForWin"]));
                                }
                            }
                        }
                    }                                        
                }
                return games;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return new List<Game>(); }
        }

        public Game? GetGame(int gameID)
        {
            try
            {
                Game? game = null;
                List<Player> players = new();

                using (MySqlConnection con = new(database.Connection))
                {
                    using (MySqlCommand command = new("select * from players where gameID=@id", con))
                    {
                        con.Open();
                        command.Parameters.AddWithValue("@id", gameID);

                        using (MySqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    players.Add(new Player((int)dataReader["id"], dataReader.GetString(1),
                                        (int)dataReader["tournamentID"], (int)dataReader["gameID"],
                                        dataReader.GetInt32(2), dataReader.GetInt32(4), dataReader.GetInt32(5),
                                        dataReader.GetInt32(3)));
                                }
                            }
                        }
                    }
                    using(MySqlCommand command = new("select * from schedule where gameID=@id",con))
                    {
                        using (MySqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    game = new((int)dataReader["gameID"], (int)dataReader["tournamentID"], players, dataReader["result"].ToString(), (bool)dataReader["finished"], (bool)dataReader["twoPointsForWin"]);
                                }
                            }
                        }
                    }

                    return game;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return null; }
        }
        
        public bool UpdateGame(Game game)
        {
            try
            {
                using (MySqlConnection con = new(new Database().Connection))
                {
                    con.Open();
                    using (MySqlCommand command = new("update schedule set result=@result," +
                        "finished=@finished, tournamentID=@tournamentID, twoPointsForWin=@points " +
                        "where gameID=@gameID", con))
                    {

                        command.Parameters.AddWithValue("@result", game.Result);
                        command.Parameters.AddWithValue("@finished", game.Finished);
                        command.Parameters.AddWithValue("@tournamentID", game.TournamentID);
                        command.Parameters.AddWithValue("@gameID", game.ID);
                        command.Parameters.AddWithValue("@points", game.TwoPointsForWin);

                        command.ExecuteNonQuery();
                        return true;
                    }
                }
                
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }
    }
}
