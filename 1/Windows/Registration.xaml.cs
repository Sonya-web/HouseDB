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
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace _1.Windows
{
	/// <summary>
	/// Логика взаимодействия для Registration.xaml
	/// </summary>
	public partial class Registration : Window
	{
        public Registration()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Хэширование пароля
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }

        /// <summary>
        /// Переход на окно авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoLbl_MouseDown(object sender, MouseButtonEventArgs e)
		{
            Authorization auto = new Authorization();
            auto.Show();
            this.Close();
		}

        /// <summary>
        /// Обработка события для регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void EnterBtn_Click(object sender, RoutedEventArgs e)
		{
            try
            {
                if (LoginTxt.Text != null && PswdTxt.Text != null && EmailTxt.Text != null && NameTxt.Text != null && SurnameTxt.Text != null)
                {
                    string Role = "User";
                    if (LoginTxt.Text.Length < 4)
                    {
                        MessageBox.Show("Слишком слабый логин!");
                        LoginTxt.Background = Brushes.Red;
                    }
                    else if (PswdTxt.Text.Length < 6)
                    {
                        MessageBox.Show("Слишком слабый пароль!");
                        PswdTxt.Background = Brushes.Red;
                    }
                    else
                    {
                        using (sakila.HouseDBContext db = new sakila.HouseDBContext())
                        {
                            LoginTxt.ToolTip = "";
                            LoginTxt.Background = Brushes.Transparent;
                            PswdTxt.ToolTip = "";
                            PswdTxt.Background = Brushes.Transparent;
                            EmailTxt.ToolTip = "";
                            EmailTxt.Background = Brushes.Transparent;
                            NameTxt.ToolTip = "";
                            NameTxt.Background = Brushes.Transparent;
                            SurnameTxt.ToolTip = "";
                            SurnameTxt.Background = Brushes.Transparent;

                            sakila.Users user = new sakila.Users(LoginTxt.Text, this.GetHashString(PswdTxt.Text), EmailTxt.Text, NameTxt.Text, SurnameTxt.Text, Role, Convert.ToDateTime(null), null, null);
                            db.Users.Add(user);
                            db.SaveChanges();
                            MessageBox.Show("Вы успешно прошли регистрацию!");
                            Realty realty = new Realty();
                            realty.Show();
                            this.Close();
                        }
                    }
                }
                else if (LoginTxt.Text == null && PswdTxt.Text == null && EmailTxt.Text == null && NameTxt.Text == null && SurnameTxt.Text == null)
                {
                    MessageBox.Show("Вы забыли ввести данные!");
                }
                else
                {
                    MessageBox.Show("Пользователь с данным логином уже существует!");
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
	}
}
