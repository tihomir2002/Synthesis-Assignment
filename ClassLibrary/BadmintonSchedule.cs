namespace ClassLibrary
{
    public class BadmintonSchedule : IGameScheduler
    {
        List<Game> games;
        int tournamentID;
        int durationDays;
        ITournamentSystem tournamentSystem;

        public List<Game> Games { get => games; }
        public int TournamentID { get => tournamentID; }
        
        public BadmintonSchedule(int tournamentID,ITournamentSystem tournamentSystem,int durationDays,List<Game> games)
        {
            this.games = games;
            this.tournamentID = tournamentID;
            this.tournamentSystem = tournamentSystem;
            this.durationDays = durationDays;
        }

        public BadmintonSchedule(int tournamentID, ITournamentSystem tournamentSystem, int durationDays)
        {
            this.tournamentID=tournamentID;
            games = new();
            this.tournamentSystem = tournamentSystem;
            this.durationDays=durationDays;
        }

        public void Generate()
        {
            List<Player> players =
                new PlayersAccessLayer(new Database()).GetAllTournamentPlayers(TournamentID);
            if (players.Count < 2) return;

            for (int i = 0; i < durationDays; i++)
            {
                GenerateForSpecificDay(players, i);
            }
        }

        private void GenerateForSpecificDay(List<Player>players,int currentDay)
        {
                var matchups = tournamentSystem.GeneratePlayerMatchUps(players, currentDay);
                foreach (KeyValuePair<Player, Player> matchup in matchups)
                {
                    games.Add(new(TournamentID, new List<Player>() { matchup.Key, matchup.Value }));
                } 
        }
    }
}
