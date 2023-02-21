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
using System.Security.Cryptography;

namespace _1.Windows
{
	/// <summary>
	/// Логика взаимодействия для Authorization.xaml
	/// </summary>
	public partial class Authorization : Window
	{
        
        public Authorization()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Метод шифрование пароля
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
        /// Переход на окно регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegLbl_MouseDown(object sender, MouseButtonEventArgs e)
		{
            Registration reg = new Registration();
            reg.Show();
            this.Close();
        }

        /// <summary>
        /// Переход на окно восстановления пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void VosLbl_MouseDown(object sender, MouseButtonEventArgs e)
		{
            Vostanovlenie1 vos = new Vostanovlenie1();
            vos.Show();
            this.Close();
        }

        /// <summary>
        /// Обработка события для авторизации пользователей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void EnterBtn_Click(object sender, RoutedEventArgs e)
		{
            try
            {
                if (LoginTxt.Text != null && this.GetHashString(PswdTxt.Text) != null)
                {
                    using (sakila.HouseDBContext db = new sakila.HouseDBContext())
                    {
                        foreach (sakila.Users user in db.Users)
                        {
                            if (LoginTxt.Text == user.Login && PswdTxt.Text == user.Password)
                            {
                                if (user.Role == "User")
                                {
                                    MessageBox.Show("Вход успешен! Поользователь " + user.Login + "!");
                                    Realty realty = new Realty();
                                    realty.Show();
                                    this.Close();
                                }
                                if (user.Role == "Admin")
                                {
                                    MessageBox.Show("Вход успешен! Администратор " + user.Login + "!");
                                    Admin admin = new Admin();
                                    admin.Show();
                                    this.Close();
                                }
                                else if (user.Role == "Realtor")
                                {
                                    MessageBox.Show("Вход успешен! Риелтор " + user.Login + "!");
                                    Moder moder = new Moder();
                                    moder.Show();
                                    this.Close();
                                    return;
                                }
                            }
                            else if (LoginTxt.Text == user.Login && PswdTxt.Text != user.Password)
                            {
                                MessageBox.Show("Пароль не совпадает!");
                            }
                        }
                    }
                }
                else if (LoginTxt.Text == null && PswdTxt.Text != null)
                {
                    MessageBox.Show("Вы не ввели логин!");
                }
                else if (LoginTxt.Text != null && PswdTxt.Text == null)
                {
                    MessageBox.Show("Вы не ввели пароль!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
	}
}
