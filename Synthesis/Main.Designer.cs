namespace Synthesis
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbTournaments = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.AddTournament = new System.Windows.Forms.Button();
            this.DeleteTournament = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRegisterResult = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTournaments
            // 
            this.lbTournaments.FormattingEnabled = true;
            this.lbTournaments.ItemHeight = 15;
            this.lbTournaments.Location = new System.Drawing.Point(6, 6);
            this.lbTournaments.Name = "lbTournaments";
            this.lbTournaments.Size = new System.Drawing.Size(696, 259);
            this.lbTournaments.TabIndex = 0;
            this.lbTournaments.SelectedIndexChanged += new System.EventHandler(this.lbTournaments_SelectedIndexChanged);
            this.lbTournaments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbTournaments_MouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(5, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(713, 310);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbTournaments);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(705, 282);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tournament";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AddTournament
            // 
            this.AddTournament.Location = new System.Drawing.Point(15, 350);
            this.AddTournament.Name = "AddTournament";
            this.AddTournament.Size = new System.Drawing.Size(109, 23);
            this.AddTournament.TabIndex = 3;
            this.AddTournament.Text = "Add Tournament";
            this.AddTournament.UseVisualStyleBackColor = true;
            this.AddTournament.Click += new System.EventHandler(this.AddTournament_Click);
            // 
            // DeleteTournament
            // 
            this.DeleteTournament.Location = new System.Drawing.Point(601, 350);
            this.DeleteTournament.Name = "DeleteTournament";
            this.DeleteTournament.Size = new System.Drawing.Size(117, 23);
            this.DeleteTournament.TabIndex = 4;
            this.DeleteTournament.Text = "Delete Tournament";
            this.DeleteTournament.UseVisualStyleBackColor = true;
            this.DeleteTournament.Visible = false;
            this.DeleteTournament.Click += new System.EventHandler(this.DeleteTournament_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(658, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Log out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search by id:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(89, 6);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(130, 350);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(109, 23);
            this.btnSchedule.TabIndex = 8;
            this.btnSchedule.Text = "Schedule";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Visible = false;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(463, 350);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(132, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh tournaments";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRegisterResult
            // 
            this.btnRegisterResult.Location = new System.Drawing.Point(295, 350);
            this.btnRegisterResult.Name = "btnRegisterResult";
            this.btnRegisterResult.Size = new System.Drawing.Size(109, 23);
            this.btnRegisterResult.TabIndex = 10;
            this.btnRegisterResult.Text = "Register Result";
            this.btnRegisterResult.UseVisualStyleBackColor = true;
            this.btnRegisterResult.Visible = false;
            this.btnRegisterResult.Click += new System.EventHandler(this.btnRegisterResult_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 378);
            this.Controls.Add(this.btnRegisterResult);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSchedule);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeleteTournament);
            this.Controls.Add(this.AddTournament);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "DualSys Inc.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lbTournaments;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private System.Windows.Forms.Timer timer1;
        private Button AddTournament;
        private Button DeleteTournament;
        private Button button1;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private Button btnSchedule;
        private Button btnRefresh;
        private Button btnRegisterResult;
    }
}