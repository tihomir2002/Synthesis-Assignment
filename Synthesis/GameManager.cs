using ClassLibrary;

namespace Synthesis
{
    public class GameManager
    {
        public GameManager()
        {

        }
        public List<Game> GetAllTournamentGames(int tournamentID)
        {
            return new GamesAccessLayer(new Database()).GetAllTournamentGames(tournamentID);
        }

        public void UpdateGameInfo(Game game)
        {
             new GamesAccessLayer(new Database()).UpdateGame(game);
        }

        public string RegisterPlayerResult(Game game, int sideOnePoints,int sideTwoPoints)
        {
            Sport sport = new TournamentManager().GetTournament(game.TournamentID).Sport;

            if(!game.TwoPointsForWin)
            {
                game.TwoPointsForWin = (sideOnePoints == 20 && sideOnePoints == sideTwoPoints);
            }

            string winner = sport.ValidateResult(sideOnePoints, sideTwoPoints,game.TwoPointsForWin);

            if (winner != "invalid")
            {
                game.Result = $"{sideOnePoints}-{sideTwoPoints}";
                UpdateGameInfo(game);
                return winner;
            }
            return winner;
        }
    }
}
