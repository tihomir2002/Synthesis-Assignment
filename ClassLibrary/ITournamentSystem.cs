namespace ClassLibrary
{
    public interface ITournamentSystem
    {
        public string Name { get; }
        public Dictionary<Player, Player> GeneratePlayerMatchUps(List<Player> players, int currentDay);
    }
}
