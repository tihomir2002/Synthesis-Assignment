using ClassLibrary;

namespace Synthesis
{
    public class TournamentManager
    {
        private TournamentData data;
        public TournamentData Data { get { return data; } }
        private List<int> nonStartedIDs = new();
        public List<int> NonStartedIDs { get => nonStartedIDs; }

        public TournamentManager()
        {
            data = new TournamentData(this);
        }

        public void CreateTournament(Tournament tournament)
        {
            new TournamentAccessLayer(new Database()).CreateTournament(tournament);
        }

        public Tournament? GetTournament(int tournamentID)
        {
            return new TournamentAccessLayer(new Database()).GetTournament(tournamentID);
        }

        public List<Tournament> GetAllTournaments()
        {
            return new TournamentAccessLayer(new Database()).GetAllTournaments();
        }

        public List<int> GetAllTournamentIDs()
        {
            List<Tournament> tournaments = GetAllTournaments();
            List<int> ids = new();
            foreach (Tournament tournament in tournaments)
            {
                ids.Add(tournament.ID);
            }
            return ids;
        }

        public bool IsIDFree(int id)
        {
            return !GetAllTournamentIDs().Contains(id);
        }

        public void CheckForStartedTournaments()
        {
            nonStartedIDs.Clear();
            List<Tournament> tournaments = GetAllTournaments();

            foreach (Tournament tournament in tournaments)
            {
                bool result = tournament.TryStartTournament();
                if (!result) nonStartedIDs.Add(tournament.ID);
                new TournamentAccessLayer(new Database()).EditTournament(tournament);
            }
        }

        public void EditTournament(Tournament tournament)
        {
            new TournamentAccessLayer(new Database()).EditTournament(tournament);
        }

        public void DeleteTournament(int tournamentID)
        {
            new TournamentAccessLayer(new Database()).DeleteTournament(tournamentID);
        }
    }
}
