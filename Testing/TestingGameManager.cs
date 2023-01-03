using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System.Collections.Generic;

namespace Testing
{
    //[TestClass]
    public class TestingGameManager
    {
        [TestMethod]
        public void RegisterPlayerResult()
        {
            Game game = new GamesAccessLayer(new Database()).GetGame(3);
            int sideOnePoints = 20, sideTwoPoints = 20;

            Sport sport = new TournamentAccessLayer(new Database()).GetTournament(game.TournamentID).Sport;
            game.TwoPointsForWin = (sideOnePoints == 20 && sideOnePoints == sideTwoPoints);

            string valid = sport.ValidateResult(sideOnePoints, sideTwoPoints);
            bool result = false;

            if (valid != "invalid")
            {
                game.Result = $"{sideOnePoints}-{sideTwoPoints}";
                new GamesAccessLayer(new Database()).UpdateGame(game);
                result = true;
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetWinner()
        {
            int sideOnePoints = 20, sideTwoPoints = 20;
            Game game = new(3,5, new PlayersAccessLayer(new Database()).GetAllTournamentPlayers(5),"",false);
            Sport sport = new TournamentAccessLayer(new Database()).GetTournament(game.TournamentID).Sport;
            string result = sport.DetermineWinner(sideOnePoints, sideTwoPoints);

            Assert.AreNotEqual("invalid", result);
        }

        [TestMethod]
        public string DetermineWinner()
        {
            int sideOnePoints = 20, sideTwoPoints = 20;
            bool twoPointsForWin = false;

            if (sideOnePoints >= 30 || sideTwoPoints > 30) return "invalid";
            if (sideOnePoints == 20 && sideTwoPoints == 20)
            {
                twoPointsForWin = true;
            }
            if (!twoPointsForWin)
            {
                if (sideOnePoints == 21 && sideOnePoints - sideTwoPoints >= 2) return "one";
                if (sideTwoPoints == 21 && sideTwoPoints - sideOnePoints >= 2) return "two";
                if (sideTwoPoints > 21 || sideOnePoints > 21) return "invalid";
                return "none";
            }
            else
            {
                if (sideOnePoints - sideTwoPoints >= 2) return "one";
                if (sideTwoPoints - sideOnePoints >= 2) return "two";
                if (sideOnePoints == 30) return "one";
                if (sideTwoPoints == 30) return "two";
                if (sideTwoPoints > 30 || sideOnePoints > 30) return "invalid";
                return "none";
            }
        }

        [TestMethod]
        public void GeneratePlayerMatchUps()
        {
            Dictionary<Player, Player> matchups = new Dictionary<Player, Player>();
            List<Player> players = new PlayersAccessLayer(new Database()).GetAllTournamentPlayers(5); 
            int currentDay = 5;
            
            currentDay = currentDay <= 0 ? 0 : currentDay - 1;
            matchups = new Round_Robin().UpdateEveryPlayer(players, currentDay);

            Assert.IsTrue(matchups.Count > 0);
        }

        [TestMethod]
        public void UpdateEveryPlayer()
        {
            List<Player> playerList = new PlayersAccessLayer(new Database()).GetAllTournamentPlayers(5);
            Player playerOne = playerList[0];
            int currentDay = 5;

            Player playerTwo = playerList[new Round_Robin().UpdatePlayer(playerList.Count - 1, playerList, currentDay)];
            Dictionary<Player, Player> matchUps = new();

            matchUps.Add(playerOne, playerTwo);

            for (int j = 1; j < playerList.Count / 2; j++)
            {
                playerOne = playerList[new Round_Robin().UpdatePlayer(j, playerList, currentDay)];
                playerTwo = playerList[new Round_Robin().UpdatePlayer(playerList.Count - j, playerList, currentDay)];
                matchUps.Add(playerOne, playerTwo);
            }

            Assert.IsTrue(matchUps.Count > 0);
        }
    }


}
