namespace ClassLibrary
{
    public abstract class Sport
    {
        protected string name = "";
        protected List<ITournamentSystem> supportedTournametSystems = new();

        public string Name { get { return name; } }
        public List<ITournamentSystem> SupportedTournametSystems { get { return supportedTournametSystems; } }

        public abstract string DetermineWinner(int sideOnePoints,int sideTwoPoints, bool twoPointsForWin = false);
        public abstract string ValidateResult(int sideOnePoints, int sideTwoPoints, bool twoPointsForWin = false);
        public override string ToString()
        {
            return name;
        }
    }
}
