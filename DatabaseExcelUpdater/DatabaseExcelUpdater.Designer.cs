namespace DatabaseExcelUpdater
{
	partial class DatabaseExcelUpdater
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
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.listBox = new System.Windows.Forms.ListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.startBtn = new System.Windows.Forms.Button();
			this.pauseBtn = new System.Windows.Forms.Button();
			this.stopBtn = new System.Windows.Forms.Button();
			this.informationLabel = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.userTextBox = new System.Windows.Forms.TextBox();
			this.databaseTextBox = new System.Windows.Forms.TextBox();
			this.serverTextBox = new System.Windows.Forms.TextBox();
			this.fileNameTextBox = new System.Windows.Forms.TextBox();
			this.openButton = new System.Windows.Forms.Button();
			this.bruttoPriceCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Excel|*.xls";
			// 
			// listBox
			// 
			this.listBox.FormattingEnabled = true;
			this.listBox.Location = new System.Drawing.Point(323, 14);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(394, 225);
			this.listBox.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 121);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Hasło";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 95);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Użytkownik";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Baza danych";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Serwer";
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(94, 118);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size(221, 20);
			this.passwordTextBox.TabIndex = 5;
			this.passwordTextBox.Text = "zaq12wsx";
			this.passwordTextBox.UseSystemPasswordChar = true;
			// 
			// startBtn
			// 
			this.startBtn.Location = new System.Drawing.Point(13, 216);
			this.startBtn.Name = "startBtn";
			this.startBtn.Size = new System.Drawing.Size(93, 23);
			this.startBtn.TabIndex = 6;
			this.startBtn.Text = "Start";
			this.startBtn.UseVisualStyleBackColor = true;
			this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
			// 
			// pauseBtn
			// 
			this.pauseBtn.Location = new System.Drawing.Point(224, 216);
			this.pauseBtn.Name = "pauseBtn";
			this.pauseBtn.Size = new System.Drawing.Size(93, 23);
			this.pauseBtn.TabIndex = 8;
			this.pauseBtn.Text = "Wstrzymaj";
			this.pauseBtn.UseVisualStyleBackColor = true;
			this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
			// 
			// stopBtn
			// 
			this.stopBtn.Location = new System.Drawing.Point(118, 216);
			this.stopBtn.Name = "stopBtn";
			this.stopBtn.Size = new System.Drawing.Size(93, 23);
			this.stopBtn.TabIndex = 7;
			this.stopBtn.Text = "Stop";
			this.stopBtn.UseVisualStyleBackColor = true;
			this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
			// 
			// informationLabel
			// 
			this.informationLabel.AutoSize = true;
			this.informationLabel.Location = new System.Drawing.Point(11, 197);
			this.informationLabel.Name = "informationLabel";
			this.informationLabel.Size = new System.Drawing.Size(59, 13);
			this.informationLabel.TabIndex = 15;
			this.informationLabel.Text = "Information";
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(14, 167);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(303, 23);
			this.progressBar.TabIndex = 14;
			// 
			// userTextBox
			// 
			this.userTextBox.Location = new System.Drawing.Point(94, 92);
			this.userTextBox.Name = "userTextBox";
			this.userTextBox.Size = new System.Drawing.Size(221, 20);
			this.userTextBox.TabIndex = 4;
			this.userTextBox.Text = "root";
			// 
			// databaseTextBox
			// 
			this.databaseTextBox.Location = new System.Drawing.Point(94, 66);
			this.databaseTextBox.Name = "databaseTextBox";
			this.databaseTextBox.Size = new System.Drawing.Size(221, 20);
			this.databaseTextBox.TabIndex = 3;
			this.databaseTextBox.Text = "tt_testsklep";
			// 
			// serverTextBox
			// 
			this.serverTextBox.Location = new System.Drawing.Point(94, 40);
			this.serverTextBox.Name = "serverTextBox";
			this.serverTextBox.Size = new System.Drawing.Size(221, 20);
			this.serverTextBox.TabIndex = 2;
			this.serverTextBox.Text = "localhost";
			// 
			// fileNameTextBox
			// 
			this.fileNameTextBox.Location = new System.Drawing.Point(94, 14);
			this.fileNameTextBox.Name = "fileNameTextBox";
			this.fileNameTextBox.Size = new System.Drawing.Size(221, 20);
			this.fileNameTextBox.TabIndex = 1;
			this.fileNameTextBox.Text = "Wczytywany plik";
			this.fileNameTextBox.Enter += new System.EventHandler(this.fileNameTextBox_Enter);
			this.fileNameTextBox.Leave += new System.EventHandler(this.fileNameTextBox_Leave);
			// 
			// openButton
			// 
			this.openButton.Location = new System.Drawing.Point(12, 12);
			this.openButton.Name = "openButton";
			this.openButton.Size = new System.Drawing.Size(69, 23);
			this.openButton.TabIndex = 0;
			this.openButton.Text = "Otwórz";
			this.openButton.UseVisualStyleBackColor = true;
			this.openButton.Click += new System.EventHandler(this.openButton_Click);
			// 
			// bruttoPriceCheckBox
			// 
			this.bruttoPriceCheckBox.AutoSize = true;
			this.bruttoPriceCheckBox.Checked = true;
			this.bruttoPriceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.bruttoPriceCheckBox.Location = new System.Drawing.Point(94, 144);
			this.bruttoPriceCheckBox.Name = "bruttoPriceCheckBox";
			this.bruttoPriceCheckBox.Size = new System.Drawing.Size(87, 17);
			this.bruttoPriceCheckBox.TabIndex = 16;
			this.bruttoPriceCheckBox.Text = "Cena brutto?";
			this.bruttoPriceCheckBox.UseVisualStyleBackColor = true;
			// 
			// DatabaseExcelUpdater
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(728, 251);
			this.Controls.Add(this.bruttoPriceCheckBox);
			this.Controls.Add(this.openButton);
			this.Controls.Add(this.fileNameTextBox);
			this.Controls.Add(this.listBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.startBtn);
			this.Controls.Add(this.pauseBtn);
			this.Controls.Add(this.stopBtn);
			this.Controls.Add(this.informationLabel);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.userTextBox);
			this.Controls.Add(this.databaseTextBox);
			this.Controls.Add(this.serverTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "DatabaseExcelUpdater";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DatabaseExcelUpdater";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseExcelUpdater_FormClosing);
			this.Load += new System.EventHandler(this.DatabaseExcelUpdater_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ListBox listBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Button startBtn;
		private System.Windows.Forms.Button pauseBtn;
		private System.Windows.Forms.Button stopBtn;
		private System.Windows.Forms.Label informationLabel;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.TextBox userTextBox;
		private System.Windows.Forms.TextBox databaseTextBox;
		private System.Windows.Forms.TextBox serverTextBox;
		private System.Windows.Forms.TextBox fileNameTextBox;
		private System.Windows.Forms.Button openButton;
		private System.Windows.Forms.CheckBox bruttoPriceCheckBox;
	}
}

