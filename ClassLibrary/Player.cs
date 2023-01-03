namespace ClassLibrary
{
    public class Player:IComparable<Player>
    {
        private string name;
        private int points;
        private int id;
        private int gamesWon;
        private int gamesLost;
        private int rank;
        private int? gameID;
        private int tournamentID;

        public string Name { get => name; }
        public int ID { get=>id; }
        public int Points { get => points; set => points = value; }
        public int GamesWon { get => gamesWon;}
        public int GamesLost { get => gamesLost;}
        public int Rank { get => rank; }
        public int? GameID { get => gameID; }
        public int TournamentID { get => tournamentID; set => tournamentID = value; }

        public Player(int id, string name, int tournamentID,int? gameID = null)
        {
            this.id = id;
            this.name = name;
            points = 0;
            gamesWon = 0;
            gamesLost = 0;
            rank = 0;
            this.gameID = gameID;
            this.tournamentID = tournamentID;
        }

        public Player(int id,string name, int tournamentID, int gameID,int points,int gamesWon,int gamesLost,int rank)
        {
            this.id = id;
            this.name = name;
            this.gamesLost = gamesLost;
            this.points = points;
            this.gamesWon = gamesWon;
            this.rank = rank;
            this.gameID = gameID;
            this.tournamentID = tournamentID;
        }

        public override string ToString()
        {
            return $"{name} - id:{id} - Rank:{rank}";
        }

        public int CompareTo(Player? other)
        {
            if (other == null) return 0;
            if (rank < other.rank) return -1;
            if (rank > other.rank) return 1;
            return 0;
        }
    }
}
