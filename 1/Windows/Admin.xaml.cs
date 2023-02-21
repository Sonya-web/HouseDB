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
	/// Логика взаимодействия для Admin.xaml
	/// </summary>
	public partial class Admin : Window
	{
		sakila.HouseDBContext db = new sakila.HouseDBContext();
		public Admin()
		{
			InitializeComponent();
			MainFrame.Navigate(new Pages.UsersPage());			
		}

		private void MainFrame_ContentRendered(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// Обработка события для выхода из панели администратора
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExitLbl_MouseDown(object sender, MouseButtonEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?", "Выход из системы", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
			{
				Authorization auto = new Authorization();
				auto.Show();
				this.Close();
			}
			else if (result == MessageBoxResult.No)
			{
				this.Show();
			}
		}

		/// <summary>
		/// Переход на страницу для добавления пользователя
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UsersLbl_MouseDown(object sender, MouseButtonEventArgs e)
		{
			MainFrame.Navigate(new Pages.AddPage());			
		}

		/// <summary>
		/// Переход на страницу для добавление риелтора
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RealtorsLbl_MouseDown(object sender, MouseButtonEventArgs e)
		{
			MainFrame.Navigate(new Pages.AddRealtor());
		}

		/// <summary>
		/// Переход на страницу со списком пользователей
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SpisokLbl_MouseDown(object sender, MouseButtonEventArgs e)
		{
			MainFrame.Navigate(new Pages.UsersPage());
		}
	}
}
