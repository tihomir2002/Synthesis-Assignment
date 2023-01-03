using ClassLibrary;

namespace SynthesisSite
{
    public class TournamentTable
    {
        public List<Tournament> tournaments = new List<Tournament>();

        public TournamentTable(int registeredTournamentID = -1)
        {
            tournaments = GetAvailableTournaments(registeredTournamentID);
        }

        public static List<Player> GetParticipatingPlayers(int tournamentID, bool ordered = false)
        {
            return new PlayersAccessLayer(new Database()).GetAllTournamentPlayers(tournamentID, ordered);
        }

        /*public string GetTournamentStatistics(int tournamentID, out List<string> scheduleInfo)
        {
            scheduleInfo = new();

            Tournament? tournament = new TournamentAccessLayer(new Database()).GetTournament(tournamentID);
            if (tournament == null) return "Tournament doesn't exist";

            //BadmintonSchedule? schedule = new ScheduleManager().GetSchedule(tournamentID);
            //if (schedule == null) return "Schedule doesn't exist";
            //scheduleInfo = schedule.GetScheduleInfo();

            return tournament.ToString();
        }
        */
        public List<Tournament> GetAvailableTournaments(int registeredTournament)
        {
            List<Tournament> tournaments = new TournamentAccessLayer(new Database()).GetAllTournaments();
            List<Tournament> availableTournaments = new();

            foreach (Tournament tournament in tournaments)
            {
                bool isOneWeekBefore = tournament.StartDate.Month == DateTime.Today.Month &&
                        tournament.StartDate.Year == DateTime.Today.Year &&
                            (tournament.StartDate.Day - DateTime.Today.Day >= 7);
                
                if(tournament.RegisteredPlayers < tournament.MaxPlayers || isOneWeekBefore)
                {
                    if(!tournament.Started)
                    {
                        if(tournament.ID != registeredTournament)
                        {
                            availableTournaments.Add(tournament);
                        }
                    }
                }
            }
            return availableTournaments;
        }

        public static List<Tournament> GetStartedTournaments()
        {
            List<Tournament> tournaments = new TournamentAccessLayer(new Database()).GetAllTournaments();
            return tournaments.FindAll(tournament => tournament.Started);
        }
    }
}
