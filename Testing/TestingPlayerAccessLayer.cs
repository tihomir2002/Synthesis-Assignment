using MySql.Data.MySqlClient;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace Testing
{
    [TestClass]
    public class TestingPlayerAccessLayer
    {
        private Database database = new();

        //[TestMethod]
        public void GetAllPlayers()
        {
            List<Player> players = new List<Player>();
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("select * from players", con);
                    MySqlDataReader dataReader = command.ExecuteReader();

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

                    Assert.AreNotEqual(0,players.Count);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual(ex.Message, ""); }
        }

        //[TestMethod]
        public void GetPlayer()
        {
            Player? player = null;
            int id = 1;
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("select * from players where id=@id", con);
                    command.Parameters.AddWithValue("@id", id);
                    MySqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            player = new Player((int)dataReader["id"], dataReader.GetString(1),
                                (int)dataReader["tournamentID"], (int)dataReader["gameID"],
                                dataReader.GetInt32(2), dataReader.GetInt32(4), dataReader.GetInt32(5),
                                dataReader.GetInt32(3));
                        }
                    }

                    Assert.IsNotNull(player);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual(ex.Message, ""); }
        }

        //[TestMethod]
        public void GetAllTournamentPlayers()
        {
            List<Player> players = new List<Player>();
            int tournamentID = 1;
            bool ordered = false;

            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("select * from players where gameID in (select gameID from schedule where @id=tournamentID)", con);
                    command.Parameters.AddWithValue("@id", tournamentID);
                    MySqlDataReader dataReader = command.ExecuteReader();

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

                    if (ordered) players.Sort();

                    Assert.AreNotEqual(0,players.Count);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual(ex.Message, ""); }
        }

        //[TestMethod]
        public void AddPlayer()
        {
            Player player = new (3,"Rob Robson",5);
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("insert ignore into players values(@id,@name,@points," +
                        "@rank,@gamesWon,@gamesLost,@tournamentID,@gameID)", con);
                    command.Parameters.AddWithValue("@id", player.ID);
                    command.Parameters.AddWithValue("@name", player.Name);
                    command.Parameters.AddWithValue("@rank", player.Rank);
                    command.Parameters.AddWithValue("@points", player.Points);
                    command.Parameters.AddWithValue("@gamesLost", player.GamesLost);
                    command.Parameters.AddWithValue("@gamesWon", player.GamesWon);
                    command.Parameters.AddWithValue("@tournamentID", player.TournamentID);
                    command.Parameters.AddWithValue("@gameID", player.GameID);

                    int rows = command.ExecuteNonQuery();

                    Assert.AreEqual(1, rows);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual(ex.Message, ""); }
        }

        //[TestMethod]
        public void EditPlayer()
        {
            Player player = new(1, "testingplayeredited", 1, 1);
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("update players values set name=@name,points=@points," +
                        "rank=@rank,gamesWon=@gamesWon,gamesLost=@gamesLost,tournamentID=@tournamentID," +
                        "gameID=@gameID where id=@id", con);
                    command.Parameters.AddWithValue("@id", player.ID);
                    command.Parameters.AddWithValue("@name", player.Name);
                    command.Parameters.AddWithValue("@rank", player.Rank);
                    command.Parameters.AddWithValue("@points", player.Points);
                    command.Parameters.AddWithValue("@gamesLost", player.GamesLost);
                    command.Parameters.AddWithValue("@gamesWon", player.GamesWon);
                    command.Parameters.AddWithValue("@tournamentID", player.TournamentID);
                    command.Parameters.AddWithValue("@gameID", player.GameID);

                    int rows = command.ExecuteNonQuery();

                    Assert.AreNotEqual(0, rows);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual(ex.Message, ""); }
        }

        //[TestMethod]
        public void DeletePlayer()
        {
            int id = 1;
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("delete from players where @id=id", con);
                    command.Parameters.AddWithValue("@id", id);

                    int rows = command.ExecuteNonQuery();
                    Assert.AreNotEqual(0, rows);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual(ex.Message, ""); }
        }
    }
}
