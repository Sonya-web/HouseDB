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

namespace _1.Pages.Realty
{
	/// <summary>
	/// Логика взаимодействия для SearchRealty.xaml
	/// </summary>
	public partial class SearchRealty : Page
	{
		public SearchRealty()
		{
			InitializeComponent();

			////установка стартовых значений для CheckBox и ComboBox
			BuyCheck.IsChecked = false;
			CountCombo.SelectedIndex = 0;

			var currentRealty = sakila.HouseDBContext.GetContext().Realty.ToList();
			LViewRealty.ItemsSource = currentRealty;
		}

		private void UpdateRealty()
		{

		}

		private void SearchTxt_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void BuyCheck_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void BuyCheck_Unchecked(object sender, RoutedEventArgs e)
		{

		}

		private void CountCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void SearchBtn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void TypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
