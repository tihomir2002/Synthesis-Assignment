using ClassLibrary;

namespace Synthesis
{
    public partial class AddTournament : Form
    {
        TournamentManager tournamentManager;

        public AddTournament(TournamentManager tournamentManager)
        {
            InitializeComponent();
            this.tournamentManager = tournamentManager;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Control control in Controls)
            {
                if ((control is TextBox || control is RichTextBox)  && string.IsNullOrWhiteSpace(control.Text))
                {
                    MessageBox.Show("Fill all fields");
                    return;
                }
            }

            if (cbSport.SelectedIndex >= 0 && cbTournamentSystems.SelectedIndex >= 0)
            {
                if (!tournamentManager.IsIDFree((int)idSelector.Value))
                {
                    MessageBox.Show("This id is not available. Choose another one.\n" +
                        $"Not available ids: {string.Join(',', tournamentManager.GetAllTournamentIDs())}");
                    return;
                }

                if ((int)maxPlayersSelector.Value < (int)minPlayersSelector.Value)
                {
                    MessageBox.Show("Minimum players cannot be more than the maximum", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ITournamentSystem tournamentSystem;
                Sport sport = new Badminton();

                if (cbTournamentSystems.SelectedItem.ToString() == "Round-Robin")
                {
                    tournamentSystem = new Round_Robin();

                    Tournament tournament = new((int)idSelector.Value, tbName.Text, rtbDesc.Text, tbLoc.Text,
                        (int)duration.Value, tournamentSystem, sport, (int)maxPlayersSelector.Value,
                        (int)minPlayersSelector.Value, dateTimePicker1.Value);
                    tournamentManager.CreateTournament(tournament);
                    MessageBox.Show("Tournament added with id:" + tournament.ID);
                }
                else if (cbTournamentSystems.SelectedItem.ToString() == "Single-Elimination")
                {
                    tournamentSystem = new Single_Elimination();

                    Tournament tournament = new((int)idSelector.Value, tbName.Text, rtbDesc.Text, tbLoc.Text,
                        (int)duration.Value, tournamentSystem, sport, (int)maxPlayersSelector.Value,
                        (int)minPlayersSelector.Value, dateTimePicker1.Value);
                    tournamentManager.CreateTournament(tournament);
                    MessageBox.Show("Tournament added with id:" + tournament.ID);
                }
                Close();
            }
            else MessageBox.Show("Select an option from the combobox");
            
        }

        private void AddTournament_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today.Add(TimeSpan.FromDays(8));
        }

        private void cbSport_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
