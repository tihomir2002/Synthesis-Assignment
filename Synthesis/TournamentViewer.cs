using ClassLibrary;

namespace Synthesis
{
    public partial class TournamentViewer : Form
    {
        Tournament tournament;
        TournamentManager tournamentManager;
        bool init = false;
        public TournamentViewer(Tournament tournament,TournamentManager tournamentManager)
        {
            InitializeComponent();
            this.tournament = tournament;
            this.tournamentManager = tournamentManager;
        }

        private void TournamentViewer_Load(object sender, EventArgs e)
        {
            tbName.Text = tournament.Name;
            rtbDesc.Text = tournament.Description;
            tbLoc.Text = tournament.Location;
            minPlayersSelector.Value = tournament.MinPlayers;
            maxPlayersSelector.Value = tournament.MaxPlayers;
            dateTimePicker1.Value = tournament.StartDate;
            duration.Value = tournament.DurationDays;
            cbSport.SelectedIndex = 0;
            checkBox1.Checked = tournament.Started;

            foreach(var item in cbTournamentSystems.Items)
            {
                if(item.ToString() == tournament.TournamentSystem.ToString())
                {
                    cbTournamentSystems.SelectedItem = item;
                }
            }

            lbParticipatingPlayers.Items.AddRange(tournamentManager.Data.GetParticipatingPlayers(tournament.ID).ToArray());

            if (lbParticipatingPlayers.Items.Count <= 0)
                lbParticipatingPlayers.Items.Add("No players have registered for this tournament");

            init = true;
        }

        private void cbSport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSport.SelectedItem.ToString() == "Badminton")
            {
                cbTournamentSystems.Items.Clear();
                cbTournamentSystems.Items.Add("Round-Robin");
                cbTournamentSystems.Items.Add("Single-Elimination");
                tournament.Sport = new Badminton();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tournament.MinPlayers>tournament.MaxPlayers)
            {
                MessageBox.Show("Minimum players cannot be more than the maximum", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            tournamentManager.EditTournament(tournament);
            MessageBox.Show("Updated tournament with id " + tournament.ID);
            Close();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            tournament.Name = tbName.Text;
        }

        private void rtbDesc_TextChanged(object sender, EventArgs e)
        {
            tournament.Description = rtbDesc.Text;
        }

        private void tbLoc_TextChanged(object sender, EventArgs e)
        {
            tournament.Location = tbLoc.Text;
        }

        private void minPlayersSelector_ValueChanged(object sender, EventArgs e)
        {
            tournament.MinPlayers = (int)minPlayersSelector.Value;
        }

        private void maxPlayersSelector_ValueChanged(object sender, EventArgs e)
        {
            tournament.MaxPlayers = (int)maxPlayersSelector.Value;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(init)
            {
                if (dateTimePicker1.Value > DateTime.Today && !tournament.Started)
                    tournament.StartDate = dateTimePicker1.Value;
                else MessageBox.Show("This date is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void duration_ValueChanged(object sender, EventArgs e)
        {
            tournament.DurationDays = (int)duration.Value;
        }

        private void cbTournamentSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTournamentSystems.SelectedItem.ToString() == "Single-Elimination")
                tournament.TournamentSystem = new Single_Elimination();
            else tournament.TournamentSystem = new Round_Robin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbParticipatingPlayers.Items.Clear();
            lbParticipatingPlayers.Items.AddRange(
                tournamentManager.Data.GetParticipatingPlayers(tournament.ID,true).ToArray());
            
            if (lbParticipatingPlayers.Items.Count <= 0) 
                lbParticipatingPlayers.Items.Add("No players have registered for this tournament");
        }
    }
}
