using MySql.Data.MySqlClient;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace Testing
{
    //[TestClass]
    public class TestingTournamentAccessLayer
    {
        private Database database = new();
        [TestMethod]
        public void GetAllTournaments()
        {
            List<Tournament> tournaments = new List<Tournament>();
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("select * from tournament", con);
                    MySqlDataReader dataReader = command.ExecuteReader();

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

                            if (schedule != null)
                            {
                                tournament = new(id, name, desc, location, days, tournamentSystem, sport, maxPlayers,
                                minPlayers, dateTime, schedule, registeredPlayers);
                            }
                            else
                            {
                                tournament = new(id, name, desc, location, days, tournamentSystem, sport, maxPlayers,
                                minPlayers, dateTime, registeredPlayers);
                            }
                        }
                    }
                    Assert.AreNotEqual(0,tournaments.Count);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual("", ex.Message); }
        }
        
        //[TestMethod]
        public void GetTournament()
        {
            int tournamentID = 5;
            try
            {
                using (MySqlConnection con = new(new Database().Connection))
                {
                    con.Open();
                    Tournament? tournament = null;
                    MySqlCommand command = new("select * from tournament where id=@id", con);
                    command.Parameters.AddWithValue("@id", tournamentID);
                    MySqlDataReader dataReader = command.ExecuteReader();

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

                            BadmintonSchedule? schedule = new ScheduleAccessLayer(database).GetSchedule(id,tournamentSystem,days);
                            int maxPlayers = (int)dataReader["maxPlayers"];
                            int minPlayers = (int)dataReader["minPlayers"];
                            DateTime dateTime = dataReader.GetDateTime(4);
                            int registeredPlayers = (int)dataReader["registeredPlayers"];

                            if(schedule != null)
                            {
                                tournament = new(id, name, desc, location, days, tournamentSystem, sport, maxPlayers,
                                minPlayers, dateTime,schedule ,registeredPlayers);
                            }
                            else
                            {
                                tournament = new(id, name, desc, location, days, tournamentSystem, sport, maxPlayers,
                                minPlayers, dateTime, registeredPlayers);
                            }
                        }
                    }
                    dataReader.Close();
                    Assert.AreNotEqual(null, tournament);
                }
            }
            catch (Exception ex) { Assert.AreEqual("", ex.Message); }
        }
        
        //[TestMethod]
        public void CreateTournament()
        {
            Tournament tournament = new(1,"","","",2,new Round_Robin(),
                new Badminton(),10,2,DateTime.Today);
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("insert ignore into tournament values(@id,@name,@desc," +
                        "@location,@date,@days,@sport,@max,@min,@system,@registered)", con);
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

                    int rows = command.ExecuteNonQuery();
                    Assert.AreNotEqual(0, rows);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual("", ex.Message); }
        }
        //[TestMethod]
        public void EditTournament()
        {
            int tournamentID = 1;
            Tournament? tournament = new TournamentAccessLayer(database).GetTournament(tournamentID);
            if (tournament != null) tournament.Location = "test location";
            else throw new ArgumentNullException();

            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("update tournament set name=@name,description=@desc," +
                        "location=@location,startDate=@date,sport=@sport,durationDays=@days," +
                        "maxPlayers=@max,minPlayers=@min,tournamentSystem=@system" +
                        " where id=@id", con);
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

                    int rows = command.ExecuteNonQuery();
                    Assert.AreNotEqual(0, rows);
                }
            }
            catch (Exception ex) { Assert.AreEqual("", ex.Message); }
        }
        
        //[TestMethod]
        public void DeleteTournament()
        {
            int id = 1;
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("delete from tournament where id=@id", con);
                    command.Parameters.AddWithValue("@id", id);
                    int rows = command.ExecuteNonQuery();
                    Assert.AreNotEqual(0, rows);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual("", ex.Message); }
        }
    }
}
