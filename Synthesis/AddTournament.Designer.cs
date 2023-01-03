namespace Synthesis
{
    partial class AddTournament
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
            this.button1 = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbLoc = new System.Windows.Forms.TextBox();
            this.cbTournamentSystems = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbdesc = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.minPlayersSelector = new System.Windows.Forms.NumericUpDown();
            this.maxPlayersSelector = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.idSelector = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.duration = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSport = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.minPlayersSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPlayersSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duration)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(116, 38);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 23);
            this.tbName.TabIndex = 1;
            // 
            // tbLoc
            // 
            this.tbLoc.Location = new System.Drawing.Point(116, 182);
            this.tbLoc.Name = "tbLoc";
            this.tbLoc.Size = new System.Drawing.Size(199, 23);
            this.tbLoc.TabIndex = 3;
            // 
            // cbTournamentSystems
            // 
            this.cbTournamentSystems.FormattingEnabled = true;
            this.cbTournamentSystems.Items.AddRange(new object[] {
            "Round-Robin",
            "Single-Elimination"});
            this.cbTournamentSystems.Location = new System.Drawing.Point(417, 41);
            this.cbTournamentSystems.Name = "cbTournamentSystems";
            this.cbTournamentSystems.Size = new System.Drawing.Size(200, 23);
            this.cbTournamentSystems.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // lbdesc
            // 
            this.lbdesc.AutoSize = true;
            this.lbdesc.Location = new System.Drawing.Point(33, 67);
            this.lbdesc.Name = "lbdesc";
            this.lbdesc.Size = new System.Drawing.Size(67, 15);
            this.lbdesc.TabIndex = 6;
            this.lbdesc.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "System";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Min Players";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Max Players";
            // 
            // minPlayersSelector
            // 
            this.minPlayersSelector.Location = new System.Drawing.Point(116, 240);
            this.minPlayersSelector.Name = "minPlayersSelector";
            this.minPlayersSelector.Size = new System.Drawing.Size(199, 23);
            this.minPlayersSelector.TabIndex = 11;
            // 
            // maxPlayersSelector
            // 
            this.maxPlayersSelector.Location = new System.Drawing.Point(117, 273);
            this.maxPlayersSelector.Name = "maxPlayersSelector";
            this.maxPlayersSelector.Size = new System.Drawing.Size(199, 23);
            this.maxPlayersSelector.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(116, 302);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Start Date";
            // 
            // idSelector
            // 
            this.idSelector.Location = new System.Drawing.Point(116, 9);
            this.idSelector.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.idSelector.Name = "idSelector";
            this.idSelector.Size = new System.Drawing.Size(199, 23);
            this.idSelector.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "ID";
            // 
            // rtbDesc
            // 
            this.rtbDesc.Location = new System.Drawing.Point(117, 67);
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.Size = new System.Drawing.Size(202, 109);
            this.rtbDesc.TabIndex = 17;
            this.rtbDesc.Text = "";
            // 
            // duration
            // 
            this.duration.Location = new System.Drawing.Point(417, 7);
            this.duration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(199, 23);
            this.duration.TabIndex = 20;
            this.duration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(331, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Duration days";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Sport";
            // 
            // cbSport
            // 
            this.cbSport.FormattingEnabled = true;
            this.cbSport.Items.AddRange(new object[] {
            "Badminton"});
            this.cbSport.Location = new System.Drawing.Point(116, 212);
            this.cbSport.Name = "cbSport";
            this.cbSport.Size = new System.Drawing.Size(200, 23);
            this.cbSport.TabIndex = 21;
            this.cbSport.SelectedIndexChanged += new System.EventHandler(this.cbSport_SelectedIndexChanged);
            // 
            // AddTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 370);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSport);
            this.Controls.Add(this.duration);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rtbDesc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.idSelector);
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
            this.Controls.Add(this.button1);
            this.Name = "AddTournament";
            this.Text = "AddTournament";
            this.Load += new System.EventHandler(this.AddTournament_Load);
            ((System.ComponentModel.ISupportInitialize)(this.minPlayersSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPlayersSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox tbName;
        private TextBox tbLoc;
        private ComboBox cbTournamentSystems;
        private Label label1;
        private Label lbdesc;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown minPlayersSelector;
        private NumericUpDown maxPlayersSelector;
        private DateTimePicker dateTimePicker1;
        private Label label7;
        private NumericUpDown idSelector;
        private Label label8;
        private RichTextBox rtbDesc;
        private NumericUpDown duration;
        private Label label9;
        private Label label2;
        private ComboBox cbSport;
    }
}