using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace DatabaseExcelUpdater
{
	class ExcelDatabaseConnector
	{
		private MySqlConnection _mySqlConnect;

		private DataSet _excelDataSet;
		private bool _priceWithoutVat;

		public bool ThreadStop;
		public bool ThreadPause;

		private readonly FormConnector _otherForm = new FormConnector();

		public void Start()
		{
			//---------------------------------- "Wyciągnięcie" potrzebnych danych z pliku excel
			var tables = _excelDataSet.Tables[0];
			var maxExcelRows = tables.Rows.Count;
			_otherForm.ChangeMaxAndMinValueInProgressBarOnform(0, maxExcelRows - 1);
			var findedProducts = 0;

			for (var i = 0; i < maxExcelRows; i++)
			{
				if (ThreadStop)
				{
					break;
				}
				if (ThreadPause)
				{
					_mySqlConnect.Ping();
					i = --i;
					continue;
				}

				//---------------------------------- Utrzymuje połączenie na cały czas trwania thread'a
				_mySqlConnect.Ping();

				var articleNr = Convert.ToInt32(tables.Rows[i][0]);
				var priceForArticle = Convert.ToDouble(tables.Rows[i][4]);

				//---------------------------------- Sprawdzenie czy dany produkt jest w bazie
				var articleId = CheckForProduct(articleNr);

				//---------------------------------- Zaaktualizowanie ceny, bądź wpisanie nowej
				AddPriceForProduct(articleId, priceForArticle);

				//---------------------------------- Wyświetlanie informacji o postępach aktualizacji
				if (articleId != 0)
				{
					_otherForm.AddInformatToListBoxOnForm(String.Format("{0}. Dodano do artykułu o numerze SKU: {1}, cenę: {2}", i + 1, articleNr, priceForArticle));
					++findedProducts;
				}
				else
				{
					_otherForm.AddInformatToListBoxOnForm(String.Format("{0}. Nie znaleziono artykułu o numerze SKU {1}", i + 1, articleNr));
				}
				
				_otherForm.ChangeProgressBarValueOnForm(i);
				_otherForm.ChangeListBoxPosition();
			}

			CloseMySqlConnection();

			if (ThreadStop || ThreadPause) return;
			FormConnector.ShowMessageBox(String.Format("Znaleziono {0} produktów z {1}. Brakuje {2} produktów w bazie.",
			                                           findedProducts, maxExcelRows, maxExcelRows - findedProducts));
			
			_otherForm.Cleanings();
		}

		public void OpenExcelWorkBook(string fileName)
		{
			//---------------------------------- Otwarcie pliku
			try
			{
				var connectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"", fileName);
				var excelConnection = new OleDbConnection(connectionString);
				excelConnection.Open();

				//pobieranie nazw "zakładek"
				var dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

				var excelSheetNames = new List<String>();
				if (dt != null)
				{
					for (var i = 0; i < dt.Rows.Count; i++)
					{
						excelSheetNames.Add(dt.Rows[i]["TABLE_NAME"].ToString());
					}
				}

				var excelSheetName = excelSheetNames[0];

				//pobieranie wszystkich wierszy
				var myCommand = new OleDbDataAdapter(String.Format("select * from [{0}]", excelSheetName), excelConnection);
				_excelDataSet = new DataSet();
				myCommand.Fill(_excelDataSet);
				excelConnection.Close();
			}
			catch (Exception ex)
			{
				FormConnector.ShowMessageBox(ex.ToString());
			}
		} 

		public void PriceWithoutVat(bool value)
		{
			//---------------------------------- Czy podana cena jest ceną netto?
			_priceWithoutVat = value;
		}

		private double CheckPrice(double price)
		{
			return _priceWithoutVat ? price / 1.22 : price;
		}

		private void AddPriceForProduct(int productNr, double price)
		{
			price = CheckPrice(price);

			if (productNr == 0) return;

			var selectQuery = String.Format("select product_id from jos_vm_product_price where product_id = {0}", productNr);
			var selectCommand = new MySqlCommand(selectQuery, _mySqlConnect).ExecuteReader();
			var priceString = price.ToString().Replace(',', '.');
				
			if (!selectCommand.Read())
			{
				selectCommand.Close();

				//nie znaleziono ceny w bazie
				var insertCommand = String.Format("insert into jos_vm_product_price (product_id, product_price, product_currency, product_price_vdate, product_price_edate, cdate, mdate, shopper_group_id, price_quantity_start, price_quantity_end) values ({0}, '{1}', 'EUR', 0, 0, 1280422085, 1280422085, 5, 0, 0)", productNr, priceString);
				new MySqlCommand(insertCommand, _mySqlConnect).ExecuteNonQuery();
			}
			else
			{
				selectCommand.Close();

				//znaleziono cenę w bazie
				var updateCommand = String.Format("update jos_vm_product_price set product_price = \"{0}\" where product_id = {1}", priceString, productNr);
				new MySqlCommand(updateCommand, _mySqlConnect).ExecuteNonQuery();

				//Euro - EUR, Poland - PLN
				updateCommand = String.Format("update jos_vm_product_price set product_currency = 'EUR' where product_id = {0}", productNr);
				new MySqlCommand(updateCommand, _mySqlConnect).ExecuteNonQuery();
			}
		}

		private int CheckForProduct(int articleNr)
		{
			var selectQuery = String.Format("select product_id from jos_vm_product where product_sku = \"{0}\" or attribute like \"%{0}%\"", articleNr);
			var selectCommand = new MySqlCommand(selectQuery, _mySqlConnect).ExecuteReader();

			if (!selectCommand.Read())
			{
				selectCommand.Close();
				return 0;
			}
			
			var temp = selectCommand.GetInt32("product_id");
			selectCommand.Close();
			return temp;
		}

		public bool OpenMySqlConnection(string server, string database, string user, string password)
		{
			//---------------------------------- Otwarcie połączenia do bazy
			var mySqlConnection =
				new MySqlConnection(String.Format("Server={0};Database={1};Uid={2};Pwd={3}", server, database, user, password));
			try
			{
				mySqlConnection.Open();
			}
			catch (MySqlException)
			{
				return false;
			}
			_mySqlConnect = mySqlConnection;

			return true;
		}

		public void CloseMySqlConnection()
		{
			//---------------------------------- Zamknięcie połączenia bazy
			if (_mySqlConnect == null) {}
			else
			{
				try
				{
					_mySqlConnect.Close();
				}
				catch(Exception) {}
			}
		}
	}
}
