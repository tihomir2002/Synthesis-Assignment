using ClassLibrary;

namespace Synthesis
{
    public class TournamentData
    {
        private TournamentManager manager;
        //look into how each of the layers are connected + responsibility for each class
        //look into DI and where i apply it(interface not class)
        //unit tests for the logic layer
        public TournamentData(TournamentManager tournamentManager)
        {
            manager = tournamentManager;
        }

        public List<Player> GetParticipatingPlayers(int tournamentID,bool ordered = false)
        {
            return new PlayersAccessLayer(new Database()).GetAllTournamentPlayers(tournamentID, ordered);
        }

        /*public string GetTournamentStatistics(int tournamentID, out List<string> scheduleInfo)
        {
            scheduleInfo = new();
            
            Tournament? tournament = manager.GetTournament(tournamentID);
            if (tournament == null) return "Tournament doesn't exist";

            BadmintonSchedule? schedule = new ScheduleManager().GetSchedule(tournamentID);
            if (schedule == null) return "Schedule doesn't exist";
            scheduleInfo = schedule.GetScheduleInfo();

            return tournament.ToString();
        }*/

        public List<Tournament> GetAvailableTournaments()
        {
            List<Tournament> tournaments = new TournamentAccessLayer(new Database()).GetAllTournaments();


            foreach (Tournament tournament in tournaments)
            {
                bool isOneWeekBefore = tournament.StartDate.Month == DateTime.Today.Month &&
                        tournament.StartDate.Year == DateTime.Today.Year && 
                            (tournament.StartDate.Day - DateTime.Today.Day >= 7);

                if (tournament.RegisteredPlayers == tournament.MaxPlayers || !isOneWeekBefore)
                {
                    tournaments.Remove(tournament);
                }
            }

            return tournaments;
        }
    }
}
