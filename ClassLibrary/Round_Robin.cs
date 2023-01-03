namespace ClassLibrary
{
    public class Round_Robin:ITournamentSystem
    {
        private string name;

        public string Name { get { return name; } }

        public Round_Robin()
        {
            name = "Round-Robin";
        }

        public Dictionary<Player, Player> GeneratePlayerMatchUps(List<Player> players, int currentDay)
        {
            Dictionary<Player, Player> matchups = new Dictionary<Player, Player>();
            
            currentDay = currentDay <= 0 ? 0 : currentDay-1;
            matchups = UpdateEveryPlayer(players, currentDay);

            //update db with ids

            return matchups;
        }

        public int UpdatePlayer(int playerToUpdateIndex, List<Player> playerList, int currentDay)
        {
            for (int i = 0; i < currentDay; i++)
            {
                playerToUpdateIndex--;

                if (playerToUpdateIndex <= 0) playerToUpdateIndex = playerList.Count - 1;
            }

            return playerToUpdateIndex;
        }

        public Dictionary<Player, Player> UpdateEveryPlayer(List<Player> playerList, int currentDay)
        {
            Player playerOne = playerList[0];
            Player playerTwo = playerList[UpdatePlayer(playerList.Count - 1, playerList, currentDay)];
            Dictionary<Player, Player> matchUps = new();
            matchUps.Add(playerOne, playerTwo);

            for (int j = 1; j < playerList.Count / 2; j++)
            {
                playerOne = playerList[UpdatePlayer(j, playerList, currentDay)];
                playerTwo = playerList[UpdatePlayer(playerList.Count - j, playerList, currentDay)];
                matchUps.Add(playerOne, playerTwo);
            }

            return matchUps;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
