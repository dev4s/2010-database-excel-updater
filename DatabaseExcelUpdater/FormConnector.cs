using System.Threading;
using System.Windows.Forms;

namespace DatabaseExcelUpdater
{
	public class FormConnector
	{
		private readonly DatabaseExcelUpdater _form;

		public FormConnector()
		{
			if (Application.OpenForms.Count != 0)
				_form = (DatabaseExcelUpdater)Application.OpenForms[0];
			else
				Thread.CurrentThread.Abort();
		}

		public void AddInformatToListBoxOnForm(string text)
		{
			_form.UpdateListBoxItemsAdd(text);
		}

		public void ChangeProgressBarValueOnForm(int value)
		{
			_form.UpdateProgessBarValue(value);
		}

		public void ChangeMaxAndMinValueInProgressBarOnform(int min, int max)
		{
			_form.UpdateProgressBarMinMaxValue(min, max);
		}

		public void ChangeListBoxPosition()
		{
			_form.UpdateListBoxAutoScroll();
		}

		public static void ShowMessageBox(string value)
		{
			MessageBox.Show(value, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public void Cleanings()
		{
			_form.UpdateSomeElementsOnForm(true);

			Thread.CurrentThread.Abort();
		}
	}
}
