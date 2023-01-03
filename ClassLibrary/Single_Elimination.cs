namespace ClassLibrary
{   
    public class Single_Elimination:ITournamentSystem
    {
        private string name;
        public string Name { get=>name; }
        
        public Single_Elimination()
        {
            name = "Single-Elimination";
        }

        public Dictionary<Player, Player> GeneratePlayerMatchUps(List<Player> players,int currentDay)
        {
            Dictionary<Player, Player> matchups = new();

            for (int i = 0; i + 1 < players.Count; i += 2)
            {
                Player playerOne = players[i];
                Player playerTwo = players[i + 1];
                matchups.Add(playerOne, playerTwo);
            }

            return matchups;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
