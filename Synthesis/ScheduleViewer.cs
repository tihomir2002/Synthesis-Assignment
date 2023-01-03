using ClassLibrary;

namespace Synthesis
{
    public partial class ScheduleViewer : Form
    {
        BadmintonSchedule? schedule = null;
        ScheduleManager manager;
        Tournament tournament;
        
        public ScheduleViewer(Tournament tournament)
        {
            InitializeComponent();
            manager = new ScheduleManager();
            this.tournament = tournament;
        }

        private void ScheduleViewer_Load(object sender, EventArgs e)
        {
            btnGenerate.Visible = true;
            schedule = manager.GetSchedule(tournament.ID, tournament.TournamentSystem, tournament.DurationDays);

            if (schedule == null || schedule.Games.Count==0)
            {
                label1.Visible = true;
                btnDelete.Visible = false; ;
                label1.Text = "This tournament does not have a schedule.";
            }
            else
            {
                label1.Visible = false;
                listBox1.Items.Clear();
                listBox1.Items.AddRange(schedule.Games.ToArray());
                btnGenerate.Visible = false;
                btnDelete.Visible = true;
            }
            listBox1.Visible = !label1.Visible;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if(tournament.RegisteredPlayers<tournament.MinPlayers)
            {
                MessageBox.Show($"Couldn't generate schedule with only {tournament.RegisteredPlayers} registered players");
                return;
            }
            
            label1.Visible = false;
            listBox1.Visible = true;
            btnDelete.Visible = true;
            listBox1.Items.Clear();
            schedule = manager.GenerateSchedule(tournament);

            listBox1.Items.AddRange(schedule.Games.ToArray()); ;
            btnGenerate.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            manager.DeleteSchedule(tournament.ID);
            MessageBox.Show("Deleted");
            Close();
        }
    }
}
