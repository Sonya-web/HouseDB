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
	/// Логика взаимодействия для AddRealtor.xaml
	/// </summary>
	public partial class AddRealtor : Page
	{
		public AddRealtor()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Обработка события для добавления риелтора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void AddBtn_Click(object sender, RoutedEventArgs e)
		{
            try
            {
                using (sakila.HouseDBContext db = new sakila.HouseDBContext())
                {
                    string Role = "Realtor";
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
                        sakila.Users users = new sakila.Users(LoginTxt.Text, PswdTxt.Text, EmailTxt.Text, NameTxt.Text, SurnameTxt.Text, Role, Convert.ToDateTime(null), null, PhoneTxt.Text);
                        db.Users.Add(users);
                        db.SaveChanges();

                        sakila.Realtor realtor = new sakila.Realtor(AgencyTxt.Text, users.Iduser);
                        db.Realtor.Add(realtor);
                        db.SaveChanges();
                        MessageBox.Show("Вы успешно зарегистрировали риелтора " + users.Login + "!");

                        LoginTxt.Text = "";
                        PswdTxt.Text = "";
                        EmailTxt.Text = "";
                        NameTxt.Text = "";
                        SurnameTxt.Text = "";
                        PhoneTxt.Text = "";
                        AgencyTxt.Text = "";
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
