using System;
using System.Collections.Generic;
using ClassLibrary;
using MySql.Data.MySqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Testing
{
    //[TestClass]
    public class TestingGamesAccessLayer
    {
        //[TestMethod]
        public void GetAllTournamentGames()
        {
            int tournamentID = 200;
            try
            {
                using (MySqlConnection con = new(new Database().Connection))
                {
                    con.Open();
                    List<Game> games = new List<Game>();
                    List<Player> players = new List<Player>();

                    MySqlCommand command = new("select * from players where tournamentID=@id", con);
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

                    command.CommandText = "select * from schedule where tournamentID=@id";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@id", tournamentID);
                    dataReader.Close();
                    dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            games.Add(new((int)dataReader["gameID"], (int)dataReader["tournamentID"], players, dataReader["result"].ToString(), (bool)dataReader["finished"]));
                        }
                    }
                    Assert.AreNotEqual(0,games.Count);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual("", ex.Message); }
        }

        //[TestMethod]
        public void GetGame()
        {
            int gameID = 1;
            try
            {
                using (MySqlConnection con = new(new Database().Connection))
                {
                    con.Open();
                    Game? game = null;
                    List<Player> players = new();
                    MySqlCommand command = new("select * from players where gameID=@id", con);
                    command.Parameters.AddWithValue("@id", gameID);
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

                    dataReader.Close();
                    command.CommandText = "select * from schedule where gameID=@id";
                    dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            game = new((int)dataReader["gameID"], (int)dataReader["tournamentID"], players, dataReader["result"].ToString(), (bool)dataReader["finished"]);
                        }
                    }
                    Assert.AreNotEqual(game,null);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual("", ex.Message); }
        }

        //[TestMethod]
        public void AddGame()
        {
            int rows = -1;
            Game game = new(1,new());
            //Game game = new(2, 200,
                //new List<Player>() { new Player(1,"reee",1,1),new Player(2,"ree5",1,1)});
            try
            {
                using (MySqlConnection con = new(new Database().Connection))
                {
                    con.Open();
                    MySqlCommand command = new("insert ignore into schedule values(@id,@tournamentID," +
                        "@result,@finished)", con);
                    command.Parameters.AddWithValue("@id", game.ID);
                    command.Parameters.AddWithValue("@result", game.Result);
                    command.Parameters.AddWithValue("@finished", game.Finished);
                    command.Parameters.AddWithValue("@tournamentID", game.TournamentID);

                    rows = command.ExecuteNonQuery();
                    foreach(KeyValuePair<int,int> kvp in game.Players)
                    {
                        command.Parameters.AddWithValue("@playerID", kvp.Key);
                        command.CommandText = "update players set gameID=@id where id=@playerID";
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id", game.ID);
                    }

                    Assert.AreNotEqual(rows,-1);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual("", ex.Message);}
        }

        //[TestMethod]
        public void UpdateGame()
        {
            int rows = 0;
            int rowsChanged = 0;
            Game game = new(1,new()); //= new(2, 300,
                //new List<Player>() { new Player(1, "reee",1,1), new Player(2, "ree5",1,1) });
            try
            {
                using (MySqlConnection con = new(new Database().Connection))
                {
                    con.Open();
                    MySqlCommand command = new("update schedule set result=@result," +
                        "finished=@finished, tournamentID=@tournamentID, " +
                        "where gameID=@gameID", con);
                    command.Parameters.AddWithValue("@result", game.Result);
                    command.Parameters.AddWithValue("@finished", game.Finished);
                    command.Parameters.AddWithValue("@tournamentID", game.TournamentID);
                    command.Parameters.AddWithValue("@gameID", game.ID);

                    rows = command.ExecuteNonQuery();

                    foreach (KeyValuePair<int, int> kvp in game.Players)
                    {
                        command.Parameters.AddWithValue("@playerID", kvp.Key);
                        command.CommandText = "update players set gameID=@gameID where id=@playerID";
                        if (command.ExecuteNonQuery() != 1)
                            rowsChanged++;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@gameID", game.ID);
                    }

                    Assert.AreNotEqual(rowsChanged,0);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual("",ex.Message);
            }
        }

        //[TestMethod]
        public void DeleteGame()
        {
            int gameID = 1;
            try
            {
                using (MySqlConnection con = new(new Database().Connection))
                {
                    con.Open();
                    MySqlCommand command = new("delete from schedule where gameID=@id)", con);
                    command.Parameters.AddWithValue("@id", gameID);
                    command.ExecuteNonQuery();
                    Assert.AreEqual(command.ExecuteNonQuery(), 1);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual("", ex.Message); }
        }
    }
}
