using System.Collections.Generic;

namespace ClassLibrary
{
    public class Game
    {
        int id;
        int tournamentID;
        Dictionary<int, int> players;
        string result="";
        bool finished;
        bool twoPointsForWin;

        public bool TwoPointsForWin { get => twoPointsForWin; set => twoPointsForWin = value; }

        public int ID { get => id; }
        public int TournamentID { get => tournamentID; }
        public string Result { get => result; set => result = value; }
        public bool Finished { get => finished; }

        public Dictionary<int,int> Players { get => players; }

        public Game(int id,int tournamentID,List<Player> players,string result, bool finished=false , bool twoPointsForWin=false)
        {
            this.id = id;
            this.tournamentID = tournamentID;
            this.result = result;
            this.twoPointsForWin = twoPointsForWin;
            this.finished = finished;
            this.players = new();
            foreach(Player player in players)
            {
                this.players.Add(player.ID,player.Points);
            }
        }

        public Game(int tournamentID, List<Player> players)
        {
            id = -1;
            this.tournamentID = tournamentID;
            this.players = new();
            foreach (Player player in players)
            {
                this.players.Add(player.ID, player.Points);
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(result))
                return $"Game Player ID: {players.ElementAt(0).Key} vs Player ID: {players.ElementAt(1).Key}";
            else return $"Game Player ID: {players.ElementAt(0).Key} vs Player ID: {players.ElementAt(1).Key}| Result:{ result}";
        }
    }
}
