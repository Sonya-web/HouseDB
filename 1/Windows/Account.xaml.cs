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
	/// Логика взаимодействия для Account.xaml
	/// </summary>
	public partial class Account : Window
	{
		public Account()
		{
			InitializeComponent();
			MainFrame.Navigate(new Pages.Account.ChangeAccountPage());
		}

		private void Label_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}

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
	}
}
