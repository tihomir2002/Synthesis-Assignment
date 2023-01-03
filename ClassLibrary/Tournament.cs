namespace ClassLibrary
{
    public class Tournament
    {
        private int id;
        private string name;
        private string description;
        private string location;
        private int durationDays;
        private Sport sport;
        private ITournamentSystem tournamentSystem;
        private int minPlayers;
        private int registeredPlayers;
        private int maxPlayers;
        private DateTime startDate;
        private DateTime endDate;
        private BadmintonSchedule schedule;
        private bool started;

        public int ID { get => id; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Location { get => location; set => location = value; }
        public int DurationDays { get => durationDays; set => durationDays = value; }
        public Sport Sport { get => sport; set => sport = value; }
        public ITournamentSystem TournamentSystem { get => tournamentSystem; set => tournamentSystem = value; }
        public int MinPlayers { get => minPlayers; set => minPlayers = value; }
        public int MaxPlayers { get => maxPlayers; set => maxPlayers = value; }
        public BadmintonSchedule Schedule { get => schedule; set => schedule = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public bool Started { get => started; }

        public DateTime EndDate { get => startDate.AddDays(DurationDays); }

        public int RegisteredPlayers { get => registeredPlayers; set => registeredPlayers = value; }

        public Tournament(int id,string name,string desc,string location,int durationDays,
            ITournamentSystem tournamentSystem,Sport sport,int maxPlayers,int minPlayers,DateTime startTime,BadmintonSchedule schedule, int registeredPlayers = 0, bool started = false)
        {
            this.id = id;
            this.name = name;
            description = desc;
            this.location = location;
            this.durationDays = durationDays;
            this.tournamentSystem = tournamentSystem;
            this.sport = sport;
            this.minPlayers = minPlayers;
            this.maxPlayers = maxPlayers;
            startDate = startTime;
            this.schedule = schedule;
            this.registeredPlayers = registeredPlayers;
            this.started = started;

            if (MaxPlayers<minPlayers) MaxPlayers = minPlayers;
        }

        public Tournament(int id, string name, string desc, string location, int durationDays,
            ITournamentSystem tournamentSystem, Sport sport, int maxPlayers, int minPlayers, DateTime startTime, int registeredPlayers = 0, bool started = false)
        {
            this.id = id;
            this.name = name;
            description = desc;
            this.location = location;
            this.durationDays = durationDays;
            this.tournamentSystem = tournamentSystem;
            this.sport = sport;
            this.minPlayers = minPlayers;
            this.maxPlayers = maxPlayers;
            startDate = startTime; 
            schedule = new BadmintonSchedule(id,tournamentSystem,durationDays);
            this.registeredPlayers = registeredPlayers;
            if (MaxPlayers < minPlayers) MaxPlayers = minPlayers;
            this.started = started;
        }

        public bool TryStartTournament()
        {
            if (registeredPlayers == 0)
            {
                started = false;
                return false;
            }

            if (!started && registeredPlayers >= MinPlayers && DateTime.Now >= StartDate)
            {
                started = true;
            }

            if (DateTime.Now < startDate)
            {
                started = false;
            }
            return started;
        }

        public override string ToString()
        {
            return $"{id} {name} {registeredPlayers}/{maxPlayers} {StartDate} Started:{started}";
        }
    }
}
