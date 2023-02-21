using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _1.Windows
{
	/// <summary>
	/// Логика взаимодействия для Realty.xaml
	/// </summary>
	public partial class Realty : Window
	{
		public Realty()
		{
			InitializeComponent();
			RealtyFrame.Navigate(new Pages.Realty.MainRealtyPage());			
		}

		private void Label_MouseDown(object sender, MouseButtonEventArgs e)
		{
			RealtyFrame.Navigate(new Pages.Realty.SearchRealty());
		}

		private void AccountImg_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Account account = new Account();
			account.Show();
			this.Close();
		}
	}
}
