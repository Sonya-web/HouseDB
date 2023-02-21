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

namespace _1.Pages.Realtor
{
	/// <summary>
	/// Логика взаимодействия для CatalogRealty.xaml
	/// </summary>
	public partial class CatalogRealty : Page
	{
		sakila.Realty realty = new sakila.Realty();
		public CatalogRealty()
		{
			InitializeComponent();
			////установка стартовых значений для CheckBox и ComboBox
			BuyCheck.IsChecked = false;
			CountCombo.SelectedIndex = 0;

			var currentRealty = sakila.HouseDBContext.GetContext().Realty.ToList();
			LViewRealty.ItemsSource = currentRealty;
		}

		private void ChangeBtn_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void DeleteBtn_Click(object sender, RoutedEventArgs e)
		{
			if (LViewRealty.SelectedItem == null)
			{
				MessageBox.Show("Вы не выбрали недвижимость!");
			}
			else
			{
				try
				{
					using (sakila.HouseDBContext db = new sakila.HouseDBContext())
					{
						MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить недвижимость?", "Удаление недвижимости", MessageBoxButton.YesNo, MessageBoxImage.Question);
						if (result == MessageBoxResult.Yes)
						{
							realty = LViewRealty.SelectedItem as sakila.Realty;
							db.Realty.Remove(realty);
							db.SaveChanges();
							LViewRealty.ItemsSource = sakila.HouseDBContext.GetContext().Realty.ToList();
							MessageBox.Show("Недвижимость удалена!");
						}
						else if (result == MessageBoxResult.No)
						{
							MessageBox.Show("Удаление отменено");
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message.ToString());
				}
			}
		}

		private void SearchTxt_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void BuyCheck_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void CountCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void TypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void SearchBtn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void BuyCheck_Unchecked(object sender, RoutedEventArgs e)
		{

		}
	}
}
