using MySql.Data.MySqlClient;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;


namespace Testing
{
    [TestClass]
    public class TestingScheduleAccessLayer
    {
        private Database database = new();
        
        //[TestMethod]
        public void GetAllSchedules()
        {
            List<BadmintonSchedule> schedules = new List<BadmintonSchedule>();
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("select * from schedule", con);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Tournament? tournament = new TournamentAccessLayer(database).GetTournament((int)reader["tournamentID"]);
                            if (tournament == null) continue;

                            List<Game>? games = new GamesAccessLayer(database).GetAllTournamentGames(tournament.ID);
                            if (games == null) continue;

                            schedules.Add(new BadmintonSchedule(tournament.ID,tournament.TournamentSystem,tournament.DurationDays, games));
                        }
                    }
                    Assert.AreNotEqual(0, schedules.Count);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual(ex.Message, ""); }
        }

        //[TestMethod]
        public void GetSchedule()
        {
            BadmintonSchedule? schedule = null;
            int tournamentID = 1;
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    MySqlCommand command = new("select * from schedule where tournamentID=@id", con);
                    command.Parameters.AddWithValue("@id", tournamentID);
                    MySqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Tournament? tournament = new TournamentAccessLayer(database).GetTournament(tournamentID);
                            if (tournament == null) continue;

                            List<Game>? games = new GamesAccessLayer(database).GetAllTournamentGames(tournament.ID);
                            if (games == null) continue;
                            schedule = new(tournament.ID, tournament.TournamentSystem, tournament.DurationDays, games);
                        }
                    }

                    Assert.IsNotNull(schedule);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual(ex.Message, ""); }
        }
        [TestMethod]
        public void AddSchedule()
        {
            int tournamentID = 5;
            Tournament? tournament = new TournamentAccessLayer(database).GetTournament(tournamentID);
            List<Game>? games = new GamesAccessLayer(database).GetAllTournamentGames(tournamentID);
            if (tournament == null) return;
            if (games == null) return;

            BadmintonSchedule schedule = new(tournament.ID, tournament.TournamentSystem, tournament.DurationDays, games);
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("insert ignore into schedule values" +
                        "(@gameID,@tournamentID,@result,@finished)", con);

                    foreach (Game game in schedule.Games)
                    {
                        command.Parameters.AddWithValue("@gameID", game.ID);
                        command.Parameters.AddWithValue("@result", game.Result);
                        command.Parameters.AddWithValue("@finished", game.Finished);
                        command.Parameters.AddWithValue("@tournamentID", schedule.TournamentID);

                        int rows = command.ExecuteNonQuery();
                        Assert.AreNotEqual(0, rows);
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual(ex.Message, ""); }
        }
        //[TestMethod]
        public void UpdateSchedule()
        {
            int tournamentID = 1;
            Tournament? tournament = new TournamentAccessLayer(database).GetTournament(tournamentID);
            List<Game>? games = new GamesAccessLayer(database).GetAllTournamentGames(tournamentID);
            if (tournament == null) return;
            if (games == null) return;

            BadmintonSchedule schedule = new(tournament.ID, tournament.TournamentSystem, tournament.DurationDays, games);
            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("update schedule values " +
                        "set tournamentID=@tournamentID,result=@result," +
                        "finished = @finished" +
                        "where gameID=@id)", con);

                    foreach (Game game in schedule.Games)
                    {
                        command.Parameters.AddWithValue("@gameID", game.ID);
                        command.Parameters.AddWithValue("@result", game.Result);
                        command.Parameters.AddWithValue("@finished", game.Finished);
                        command.Parameters.AddWithValue("@tournamentID", schedule.TournamentID);

                        int rows = command.ExecuteNonQuery();
                        Assert.AreNotEqual(0, rows);
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual(ex.Message, ""); }
        }
        //[TestMethod]
        public void DeleteSchedule()
        {
            int id = 1;

            try
            {
                using (MySqlConnection con = new(database.Connection))
                {
                    con.Open();
                    MySqlCommand command = new("delete from schedule where tournamentID=@id", con);
                    command.Parameters.AddWithValue("@id", id);

                    int rows = command.ExecuteNonQuery();
                    Assert.AreNotEqual(0, rows);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); Assert.AreEqual(ex.Message, ""); }
        }
    }
}
