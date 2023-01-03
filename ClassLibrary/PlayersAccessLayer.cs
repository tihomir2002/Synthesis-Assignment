using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class PlayersAccessLayer
    {
        private Database database;

        public PlayersAccessLayer(Database database)
        {
            this.database = database;
        }

        public List<Player> GetAllPlayers()
        {
            List<Player> players = new List<Player>();
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    using (MySqlCommand command = new("select * from players", con))
                    {
                        con.Open();
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
                }

                return players;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return players; }
        }
    
        public Player? GetPlayer(int id)
        {
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    using (MySqlCommand command = new("select * from players where id=@id", con))
                    {
                        con.Open();
                        command.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    if (dataReader["gameID"] is DBNull)
                                    {
                                        return new Player((int)dataReader["id"], dataReader["name"].ToString(),
                                        (int)dataReader["tournamentID"]);
                                    }
                                    return new Player((int)dataReader["id"], dataReader["name"].ToString(),
                                        (int)dataReader["tournamentID"], (int)dataReader["gameID"], (int)dataReader["points"], (int)dataReader["gamesWon"],
                                        (int)dataReader["gamesLost"], (int)dataReader["rank"]);
                                }
                            }
                        }

                    }
                }
                return null;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return null; }
        }

        public int GetRegisteredPlayersCount(int tournamentID)
        {
            int count = -1;
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    using (MySqlCommand command = new("select count(tournamentID) from players " +
                        "where tournamentID=@id", con))
                    {
                        con.Open();

                        command.Parameters.AddWithValue("@id", tournamentID);
                        count = Convert.ToInt32((Int64)command.ExecuteScalar());

                    }
                }
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return count;
            }
        }

        public List<Player> GetAllTournamentPlayers(int tournamentID,bool ordered=false)
        {
            List<Player> players = new List<Player>();
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    using (MySqlCommand command = new("select * from players where @id=tournamentID", con))
                    {
                        con.Open();
                        command.Parameters.AddWithValue("@id", tournamentID);

                        using (MySqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    if (dataReader["gameID"] is DBNull)
                                    {
                                        players.Add(new Player((int)dataReader["id"], dataReader["name"].ToString(),
                                        (int)dataReader["tournamentID"]));
                                    }
                                    else players.Add(new Player((int)dataReader["id"], dataReader["name"].ToString(),
                                        (int)dataReader["tournamentID"], (int)dataReader["gameID"], (int)dataReader["points"], (int)dataReader["gamesWon"],
                                        (int)dataReader["gamesLost"], (int)dataReader["rank"]));
                                }
                            }
                        }

                        if (ordered) players.Sort();

                    }
                    return players;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return players; }
        }

        public void AddPlayer(Player player)
        {
            try
            {
                using(MySqlConnection con = new(database.Connection))
                {
                    con.Open();

                    using(MySqlCommand command = new("insert ignore into players values(@id,@name,@points," +
                        "@rank,@gamesWon,@gamesLost,@tournamentID,@gameID)", con))
                    {
                        command.Parameters.AddWithValue("@id", player.ID);
                        command.Parameters.AddWithValue("@name", player.Name);
                        command.Parameters.AddWithValue("@rank", player.Rank);
                        command.Parameters.AddWithValue("@points", player.Points);
                        command.Parameters.AddWithValue("@gamesLost", player.GamesLost);
                        command.Parameters.AddWithValue("@gamesWon", player.GamesWon);
                        command.Parameters.AddWithValue("@tournamentID", player.TournamentID);
                        command.Parameters.AddWithValue("@gameID", player.GameID);

                        command.ExecuteNonQuery();
                    }                 
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public bool PlayerExists(int playerID)
        {
            try
            {
                Int64 count = -1;

                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();

                    using (MySqlCommand command = new("select count(*) from players where id=@id", con))
                    {
                        command.Parameters.AddWithValue("@id", playerID);

                        count = (Int64)command.ExecuteScalar();
                    }
                }

                if (count == 0) return false;
                else return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }

        public void EditPlayer(Player player)
        {
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    using (MySqlCommand command = new("update players set name=@name,points=@points," +
                       "rank=@rank,gamesWon=@gamesWon,gamesLost=@gamesLost,tournamentID=@tournamentID," +
                       "gameID=@gameID where id=@id", con))
                    {
                        con.Open();

                        command.Parameters.AddWithValue("@id", player.ID);
                        command.Parameters.AddWithValue("@name", player.Name);
                        command.Parameters.AddWithValue("@rank", player.Rank);
                        command.Parameters.AddWithValue("@points", player.Points);
                        command.Parameters.AddWithValue("@gamesLost", player.GamesLost);
                        command.Parameters.AddWithValue("@gamesWon", player.GamesWon);
                        command.Parameters.AddWithValue("@tournamentID", player.TournamentID);
                        command.Parameters.AddWithValue("@gameID", player.GameID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void DeletePlayer(int id)
        {
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    using (MySqlCommand command = new("delete from players where @id=id", con))
                    {
                        con.Open();
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
