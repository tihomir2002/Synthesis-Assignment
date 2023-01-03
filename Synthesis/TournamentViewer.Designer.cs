namespace Synthesis
{
    partial class TournamentViewer
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
            this.lbParticipatingPlayers = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSport = new System.Windows.Forms.ComboBox();
            this.duration = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.maxPlayersSelector = new System.Windows.Forms.NumericUpDown();
            this.minPlayersSelector = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbdesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTournamentSystems = new System.Windows.Forms.ComboBox();
            this.tbLoc = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.duration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPlayersSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minPlayersSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // lbParticipatingPlayers
            // 
            this.lbParticipatingPlayers.FormattingEnabled = true;
            this.lbParticipatingPlayers.ItemHeight = 15;
            this.lbParticipatingPlayers.Location = new System.Drawing.Point(435, 3);
            this.lbParticipatingPlayers.Name = "lbParticipatingPlayers";
            this.lbParticipatingPlayers.Size = new System.Drawing.Size(256, 334);
            this.lbParticipatingPlayers.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 42;
            this.label2.Text = "Sport";
            // 
            // cbSport
            // 
            this.cbSport.FormattingEnabled = true;
            this.cbSport.Items.AddRange(new object[] {
            "Badminton"});
            this.cbSport.Location = new System.Drawing.Point(89, 188);
            this.cbSport.Name = "cbSport";
            this.cbSport.Size = new System.Drawing.Size(200, 23);
            this.cbSport.TabIndex = 41;
            this.cbSport.SelectedIndexChanged += new System.EventHandler(this.cbSport_SelectedIndexChanged);
            // 
            // duration
            // 
            this.duration.Location = new System.Drawing.Point(89, 306);
            this.duration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(199, 23);
            this.duration.TabIndex = 40;
            this.duration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.duration.ValueChanged += new System.EventHandler(this.duration_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 15);
            this.label9.TabIndex = 39;
            this.label9.Text = "Duration days";
            // 
            // rtbDesc
            // 
            this.rtbDesc.Location = new System.Drawing.Point(90, 35);
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.Size = new System.Drawing.Size(202, 117);
            this.rtbDesc.TabIndex = 38;
            this.rtbDesc.Text = "";
            this.rtbDesc.TextChanged += new System.EventHandler(this.rtbDesc_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 35;
            this.label7.Text = "Start Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(89, 278);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 34;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // maxPlayersSelector
            // 
            this.maxPlayersSelector.Location = new System.Drawing.Point(90, 249);
            this.maxPlayersSelector.Name = "maxPlayersSelector";
            this.maxPlayersSelector.Size = new System.Drawing.Size(199, 23);
            this.maxPlayersSelector.TabIndex = 33;
            this.maxPlayersSelector.ValueChanged += new System.EventHandler(this.maxPlayersSelector_ValueChanged);
            // 
            // minPlayersSelector
            // 
            this.minPlayersSelector.Location = new System.Drawing.Point(89, 216);
            this.minPlayersSelector.Name = "minPlayersSelector";
            this.minPlayersSelector.Size = new System.Drawing.Size(199, 23);
            this.minPlayersSelector.TabIndex = 32;
            this.minPlayersSelector.ValueChanged += new System.EventHandler(this.minPlayersSelector_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "Max Players";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "Min Players";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "System";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "Location";
            // 
            // lbdesc
            // 
            this.lbdesc.AutoSize = true;
            this.lbdesc.Location = new System.Drawing.Point(6, 38);
            this.lbdesc.Name = "lbdesc";
            this.lbdesc.Size = new System.Drawing.Size(67, 15);
            this.lbdesc.TabIndex = 27;
            this.lbdesc.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "Name";
            // 
            // cbTournamentSystems
            // 
            this.cbTournamentSystems.FormattingEnabled = true;
            this.cbTournamentSystems.Location = new System.Drawing.Point(89, 343);
            this.cbTournamentSystems.Name = "cbTournamentSystems";
            this.cbTournamentSystems.Size = new System.Drawing.Size(200, 23);
            this.cbTournamentSystems.TabIndex = 25;
            this.cbTournamentSystems.SelectedIndexChanged += new System.EventHandler(this.cbTournamentSystems_SelectedIndexChanged);
            // 
            // tbLoc
            // 
            this.tbLoc.Location = new System.Drawing.Point(89, 158);
            this.tbLoc.Name = "tbLoc";
            this.tbLoc.Size = new System.Drawing.Size(199, 23);
            this.tbLoc.TabIndex = 24;
            this.tbLoc.TextChanged += new System.EventHandler(this.tbLoc_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(89, 6);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 23);
            this.tbName.TabIndex = 23;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(435, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(611, 344);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "Sort by rank";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(307, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 45;
            this.label8.Text = "Started";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(357, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 46;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // TournamentViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 379);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSport);
            this.Controls.Add(this.duration);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rtbDesc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.maxPlayersSelector);
            this.Controls.Add(this.minPlayersSelector);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbdesc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTournamentSystems);
            this.Controls.Add(this.tbLoc);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbParticipatingPlayers);
            this.MaximizeBox = false;
            this.Name = "TournamentViewer";
            this.Text = "TournamentViewer";
            this.Load += new System.EventHandler(this.TournamentViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.duration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPlayersSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minPlayersSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListBox lbParticipatingPlayers;
        private Label label2;
        private ComboBox cbSport;
        private NumericUpDown duration;
        private Label label9;
        private RichTextBox rtbDesc;
        private Label label7;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown maxPlayersSelector;
        private NumericUpDown minPlayersSelector;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label lbdesc;
        private Label label1;
        private ComboBox cbTournamentSystems;
        private TextBox tbLoc;
        private TextBox tbName;
        private Button button1;
        private Button button2;
        private Label label8;
        private CheckBox checkBox1;
    }
}