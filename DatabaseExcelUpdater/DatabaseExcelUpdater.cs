using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace DatabaseExcelUpdater
{
	public partial class DatabaseExcelUpdater : Form
	{
		private ExcelDatabaseConnector _edb;
		private Thread _programThread;

		public DatabaseExcelUpdater()
		{
			InitializeComponent();
		}

		private void DatabaseExcelUpdater_Load(object sender, EventArgs e)
		{
			informationLabel.Text = "";
			EnableStartAndDisableOtherButtonsOnForm(true);

			listBox.Items.Clear();

			_edb = new ExcelDatabaseConnector();
		}

		private void DatabaseExcelUpdater_FormClosing(object sender, FormClosingEventArgs e)
		{
			_edb.ThreadStop = true;
			_edb.CloseMySqlConnection();

			if (_programThread == null) return;

			while (_programThread.IsAlive)
			{
				_programThread.Abort();
			}
		}

		private void fileNameTextBox_Enter(object sender, EventArgs e)
		{
			if (fileNameTextBox.Text == "Wczytywany plik")
			{
				fileNameTextBox.Text = "";
			}
		}

		private void fileNameTextBox_Leave(object sender, EventArgs e)
		{
			if (fileNameTextBox.Text == "")
			{
				fileNameTextBox.Text = "Wczytywany plik";
			}
		}

		private void openButton_Click(object sender, EventArgs e)
		{
			if(openFileDialog.ShowDialog() == DialogResult.OK)
			{
				fileNameTextBox.Text = openFileDialog.FileName;
			}
		}

		private void startBtn_Click(object sender, EventArgs e)
		{
			if (CheckTextboxes()) return;

			if (_edb.ThreadStop)
			{
				_edb.ThreadStop = false;
				_edb.CloseMySqlConnection();

				informationLabel.Text = "Uruchomiono ponownie: " + DateTime.Now;
			}
			if (_programThread != null && _edb.ThreadPause)
			{
				_edb.ThreadPause = false;

				EnableStartAndDisableOtherButtonsOnForm(false);

				informationLabel.Text = "Wznowiono: " + DateTime.Now;
			}
			else if (_edb.OpenMySqlConnection(serverTextBox.Text, databaseTextBox.Text, userTextBox.Text, passwordTextBox.Text))
			{
				_edb.OpenExcelWorkBook(fileNameTextBox.Text);
				_edb.PriceWithoutVat(bruttoPriceCheckBox.Checked);

				informationLabel.Text = "Rozpoczęto: " + DateTime.Now;

				EnableSomeElementsOnForm(false);
				EnableStartAndDisableOtherButtonsOnForm(false);

				_programThread = new Thread(_edb.Start);
				_programThread.Start();
			}
			else
			{
				EnableSomeElementsOnForm(true);
				EnableStartAndDisableOtherButtonsOnForm(true);
				Error("Nastąpił błąd przy połączeniu do bazy danych, sprawdź czy wszystkie dane zostały dobrze wprowadzone");

				informationLabel.Text = "";
			}
		}

		private void pauseBtn_Click(object sender, EventArgs e)
		{
			_edb.ThreadPause = true;
			informationLabel.Text = "Wstrzymano: " + DateTime.Now;
			EnableStartAndDisableOtherButtonsOnForm(true);
		}

		private void stopBtn_Click(object sender, EventArgs e)
		{
			_edb.ThreadStop = true;
			informationLabel.Text = "Zatrzymano: " + DateTime.Now;
			EnableSomeElementsOnForm(true);
			EnableStartAndDisableOtherButtonsOnForm(true);
		}

		private void EnableSomeElementsOnForm(bool value)
		{
			fileNameTextBox.Enabled = value;
			bruttoPriceCheckBox.Enabled = value;
			openButton.Enabled = value;

			serverTextBox.Enabled = value;
			databaseTextBox.Enabled = value;
			userTextBox.Enabled = value;
			passwordTextBox.Enabled = value;
		}

		private void EnableStartAndDisableOtherButtonsOnForm(bool value)
		{
			startBtn.Enabled = value;
			stopBtn.Enabled = !value;
			pauseBtn.Enabled = !value;
		}

		private bool CheckTextboxes()
		{
			var error = false;

			if(!CheckIsThisARealFile(fileNameTextBox.Text))
			{
				Error("Podano błędny plik");
				error = true;
			}
			if (String.IsNullOrEmpty(serverTextBox.Text))
			{
				Error("Pole serwer nie może być puste");
				error = true;
			}
			if (String.IsNullOrEmpty(databaseTextBox.Text))
			{
				Error("Pole bazy danych nie może być puste");
				error = true;
			}
			if (String.IsNullOrEmpty(userTextBox.Text))
			{
				Error("Pole z nazwą użytkownika nie może być puste");
				error = true;
			}
			if (String.IsNullOrEmpty(passwordTextBox.Text))
			{
				Error("Pole z hasłem nie może być puste");
				error = true;
			}

			return error;
		}

		private static bool CheckIsThisARealFile(string fileName)
		{
			try
			{
				var fileInfo = new FileInfo(fileName);
				return fileInfo.Length != 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private static void Error(string errorText)
		{
			MessageBox.Show(errorText, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		//delegates

		private delegate void DelegateListBoxItemsAddCallback(string value);
		public void UpdateListBoxItemsAdd(string value)
		{
			if (InvokeRequired)
			{
				DelegateListBoxItemsAddCallback callback = (UpdateListBoxItemsAdd);
				Invoke(callback, new object[] {value});
			}
			else
			{
				listBox.Items.Add(value);
			}
		}

		private delegate void DelegateListBoxAutoScrollCallback();
		public void UpdateListBoxAutoScroll()
		{
			if (InvokeRequired)
			{
				DelegateListBoxAutoScrollCallback callback = (UpdateListBoxAutoScroll);
				Invoke(callback);
			}
			else
			{
				listBox.SelectedIndex = listBox.Items.Count - 1;
				listBox.SelectedIndex = -1;
			}
		}

		private delegate void DelegateProgressBarValueCallback(int value);
		public void UpdateProgessBarValue(int value)
		{
			if (InvokeRequired)
			{
				DelegateProgressBarValueCallback callback = (UpdateProgessBarValue);
				Invoke(callback, new object[] {value});
			}
			else
			{
				progressBar.Value = value;
			}
		}

		private delegate void DelegateProgressBarMinMaxValueCallback(int min, int max);
		public void UpdateProgressBarMinMaxValue(int min, int max)
		{
			if (InvokeRequired)
			{
				DelegateProgressBarMinMaxValueCallback callback = (UpdateProgressBarMinMaxValue);
				Invoke(callback, new object[] {min, max});
			}
			else
			{
				progressBar.Minimum = min;
				progressBar.Maximum = max;
			}
		}

		private delegate void DelegateEnableSomeElementsOnForm(bool value);
		public void UpdateSomeElementsOnForm(bool value)
		{
			if (InvokeRequired)
			{
				DelegateEnableSomeElementsOnForm callback = (UpdateSomeElementsOnForm);
				Invoke(callback, new object[] {value});
			}
			else
			{
				EnableSomeElementsOnForm(value);
				EnableStartAndDisableOtherButtonsOnForm(value);

				progressBar.Value = 0;
				informationLabel.Text = "Zakończono: " + DateTime.Now;
			}
		}
	}
}
