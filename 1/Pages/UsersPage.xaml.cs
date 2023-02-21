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
	/// Логика взаимодействия для UsersPage.xaml
	/// </summary>
	public partial class UsersPage : Page
	{
		sakila.Users users = new sakila.Users();
		
		public UsersPage()
		{
			InitializeComponent();
			DGUser.ItemsSource = sakila.HouseDBContext.GetContext().Users.OrderBy(x => x.Iduser).ToList();
		}

		/// <summary>
		/// Обработка события для удаления пользователя
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DeleteBtn_Click(object sender, RoutedEventArgs e)
		{
			if (DGUser.SelectedItem == null)
			{
				MessageBox.Show("Вы не выбрали пользователя!");
			}
			else
			{
				try
				{
					using (sakila.HouseDBContext db = new sakila.HouseDBContext())
					{
						MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить пользователя?", "Удаление пользователя", MessageBoxButton.YesNo, MessageBoxImage.Question);
						if (result == MessageBoxResult.Yes)
						{
							users = DGUser.SelectedItem as sakila.Users;
							db.Users.Remove(users);
							db.SaveChanges();
							DGUser.ItemsSource = sakila.HouseDBContext.GetContext().Users.OrderBy(x => x.Iduser).ToList();
							MessageBox.Show("Пользователь удален!");
						}
						else if (result == MessageBoxResult.No)
						{
							MessageBox.Show("Удаление отменено");
						}
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message.ToString());
				}
			}
		}
	}
}
