using ClassLibrary;

namespace Synthesis
{
    public partial class Result : Form
    {
        GameManager gameManager;
        List<Game> games;
        int tournamentID = -1;

        public Result(int tournamentID)
        {
            InitializeComponent();
            gameManager = new();

            this.tournamentID = tournamentID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Game game = games[listBox1.SelectedIndex];
                int sideOnePoints = (int)numericUpDown1.Value;
                int sideTwoPoints = (int)numericUpDown2.Value;
                string winner = gameManager.RegisterPlayerResult(game, sideOnePoints,sideTwoPoints);
                
                if (winner == "one" || winner == "two") MessageBox.Show("Winner is player " + winner);
                if (winner == "invalid") MessageBox.Show("Ivalid result");

                UpdateGames();
            }
            panel1.Visible = false;
        }

        private void Result_Load(object sender, EventArgs e)
        {
            UpdateGames();   
        }

        private void UpdateGames()
        {
            TournamentManager tournamentManager = new TournamentManager();
            Tournament tournament = tournamentManager.GetTournament(tournamentID);
            ScheduleManager scheduleManager = new ScheduleManager();

            games = scheduleManager.GetSchedule(tournament.ID, tournament.TournamentSystem, tournament.DurationDays).Games;
            listBox1.Items.Clear();
            listBox1.Items.AddRange(games.ToArray());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                panel1.Visible = true;
            }
            else panel1.Visible = false;
        }
    }
}
