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

namespace _1.Pages.Account
{
	/// <summary>
	/// Логика взаимодействия для ChangeAccountPage.xaml
	/// </summary>
	public partial class ChangeAccountPage : Page
	{
		public ChangeAccountPage()
		{
			InitializeComponent();
		}

		private void ChangeBtn_Click(object sender, RoutedEventArgs e)
		{
            try
            {
                if (LoginTxt.Text.Length < 4)
                {
                    MessageBox.Show("Слишком слабый логин!");
                    LoginTxt.Background = Brushes.MistyRose;
                }
                else if (PswdTxt.Text.Length < 5)
                {
                    MessageBox.Show("Слишком слабый пароль!");
                    PswdTxt.Background = Brushes.MistyRose;
                }
                else if (PhoneTxt.Text.Length != 11)
                {
                    MessageBox.Show("Телефон должен содержать 11 цифр!");
                    PhoneTxt.Background = Brushes.MistyRose;
                }
                else
                {
                    using (sakila.HouseDBContext db = new sakila.HouseDBContext())
                    {
                        foreach (sakila.Users user in db.Users)
                        {
                            user.Login = LoginTxt.Text;
                            user.Password = PswdTxt.Text;
                            user.Mail = EmailTxt.Text;
                            user.Name = NameTxt.Text;
                            user.Surname = SurnameTxt.Text;
                            user.PhoneNumber = PhoneTxt.Text;

                            db.SaveChanges();
                            MessageBox.Show("Вы изменили данные!");

                            LoginTxt.Text = user.Login;
                            PswdTxt.Text = user.Password;
                            EmailTxt.Text = user.Mail;
                            NameTxt.Text = user.Name;
                            SurnameTxt.Text = user.Surname;
                            PhoneTxt.Text = user.PhoneNumber;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
	}
}
