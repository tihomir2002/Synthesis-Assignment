using ClassLibrary;

namespace Synthesis
{
    public partial class Main : Form
    {
        Staff staff;
        Login loginForm;
        TournamentManager tournamentManager;
        LoginManager loginManager;
        bool closing = true;

        public Main(Staff staff, Login loginForm)
        {
            InitializeComponent();
            this.staff = staff;
            this.loginForm = loginForm;
            tournamentManager = new();
            loginManager = new();
            timer1.Start();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(closing)       
                Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            RefreshTournaments();
        }

        private void RefreshTournaments()
        {
            tournamentManager.CheckForStartedTournaments();
            List<Tournament> tournaments = tournamentManager.GetAllTournaments();

            lbTournaments.Items.Clear();
            if (tournaments.Count > 0)
            {
                lbTournaments.Items.AddRange(tournaments.ToArray());
            }
            else lbTournaments.Items.Add("No tournaments are available");
            btnRegisterResult.Visible = false;
        }

        private void lbTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTournaments.SelectedIndex>=0)
            {
                DeleteTournament.Visible = true;
                int selectedTournamentID = tournamentManager.GetAllTournamentIDs()[lbTournaments.SelectedIndex];
                Tournament tournament = tournamentManager.GetTournament(selectedTournamentID);

                if (tournament.RegisteredPlayers < tournament.MinPlayers)
                {
                    MessageBox.Show("Not enough players are registered for this tournament.\n" +
                        "Schedule generation and result registering are not applicable");
                    return;
                }

                if (!tournamentManager.NonStartedIDs.Contains(selectedTournamentID))
                {
                    btnRegisterResult.Visible = true;
                    btnSchedule.Visible = true;
                }
                else
                {
                    btnRegisterResult.Visible = false;
                    btnSchedule.Visible = false;
                }

            }
            else
            {
                DeleteTournament.Visible = false;
                btnSchedule.Visible = false;
                btnRegisterResult.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            closing = false;
            loginForm.Show();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!loginManager.IsConnected())
            {
                timer1.Stop();
                MessageBox.Show("Lost connection...");
                closing = false;
                loginForm.Show();
                Close();
            }
        }

        private void AddTournament_Click(object sender, EventArgs e)
        {
            new AddTournament(tournamentManager).Show();
        }

        private void DeleteTournament_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                List<Tournament> tournaments = tournamentManager.GetAllTournaments();
                tournamentManager.DeleteTournament(tournaments[lbTournaments.SelectedIndex].ID);
                RefreshTournaments();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericUpDown1.Value < 0) return;
            
            lbTournaments.Items.Clear();
            Tournament? tournament = tournamentManager.GetTournament((int)numericUpDown1.Value);

            if (tournament == null) lbTournaments.Items.Add("No tournaments with this id exists");
            else lbTournaments.Items.Add(tournament);

            DeleteTournament.Visible = false;
            btnSchedule.Visible = false;
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            Tournament tournament = tournamentManager.GetAllTournaments()[lbTournaments.SelectedIndex];            
            new ScheduleViewer(tournament).Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTournaments();
        }

        private void lbTournaments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<Tournament> tournaments = tournamentManager.GetAllTournaments();
            if (lbTournaments.SelectedIndex>=0)
            {
                new TournamentViewer(tournaments[lbTournaments.SelectedIndex],tournamentManager).Show();
            }
        }

        private void btnRegisterResult_Click(object sender, EventArgs e)
        {
            new Result(tournamentManager.GetAllTournaments()[lbTournaments.SelectedIndex].ID).Show();
        }
    }
}
