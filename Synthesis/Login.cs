using ClassLibrary;
//using MySql.Data.MySqlClient;

namespace Synthesis
{
    public partial class Login : Form
    {
        LoginManager loginManager;
        public Login()
        {
            InitializeComponent();
            loginManager = new LoginManager();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Staff? staff = loginManager.TryLogin(textBox1.Text, textBox2.Text);
            if (staff != null)
            {
                new Main(staff,this).Show();
                timer1.Stop();
                Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            label3.Text = loginManager.IsConnected() ? 
                "Connection successful" : "Unable to connect to the server.";
        }

        private void Login_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible) timer1.Start();
        }
    }
}