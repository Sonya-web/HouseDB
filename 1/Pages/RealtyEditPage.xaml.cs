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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1.Pages
{
	/// <summary>
	/// Логика взаимодействия для RealtyEditPage.xaml
	/// </summary>
	public partial class RealtyEditPage : Page
	{
		private sakila.Realty _currentRealty = new sakila.Realty();
		public RealtyEditPage(sakila.Realty selectedRealty)
		{
			InitializeComponent();
			TypeComb.ItemsSource = sakila.HouseDBContext.GetContext().Typeofrealty.ToList();


			if (selectedRealty != null)
				_currentRealty = selectedRealty;

			DataContext = _currentRealty;
		}

		private void AddBtn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ChangeBtn_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
