using ClassLibrary;

namespace Synthesis
{
    public class ScheduleManager
    {
        
        public ScheduleManager()
        {
        }

        public BadmintonSchedule GenerateSchedule(Tournament tournament)
        {
            BadmintonSchedule badmintonSchedule = new(tournament.ID, tournament.TournamentSystem, tournament.DurationDays);
            badmintonSchedule.Generate();

            AddSchedule(badmintonSchedule);
            return badmintonSchedule;
        }

        public BadmintonSchedule? GetSchedule(int tournamentID, ITournamentSystem tournamentSystem, int durationDays)
        {
            return new ScheduleAccessLayer(new Database()).GetSchedule(tournamentID,tournamentSystem,durationDays);
        }

        public void AddSchedule(BadmintonSchedule schedule)
        {
            new ScheduleAccessLayer(new Database()).AddSchedule(schedule);
        }

        public void UpdateSchedule(BadmintonSchedule schedule)
        {
            new ScheduleAccessLayer(new Database()).UpdateSchedule(schedule);
        }

        public void DeleteSchedule(int tournamentID)
        {
            new ScheduleAccessLayer(new Database()).DeleteSchedule(tournamentID);
        }
    }
}
