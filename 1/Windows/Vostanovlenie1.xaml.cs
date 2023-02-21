using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
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
	/// Логика взаимодействия для Vostanovlenie1.xaml
	/// </summary>
	public partial class Vostanovlenie1 : Window
	{
		public Vostanovlenie1()
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

		public char a, a1, a2, a3, a4, a5;

		/// <summary>
		/// Обработка события для восстановления пароля
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SendBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				MailAddress from = new MailAddress("cinema_maso@mail.ru", "Агенство недвижимости 'Хаус'!");
				MailAddress to = new MailAddress(EmailTxt.Text);
				MailMessage m = new MailMessage(from, to);
				m.Subject = "Восстановление пароля!";
				Random random = new Random();

				a = (Char)random.Next(33, 90);
				a1 = (Char)random.Next(33, 90);
				a2 = (Char)random.Next(33, 90);
				a3 = (Char)random.Next(33, 90);
				a4 = (Char)random.Next(33, 90);
				a5 = (Char)random.Next(33, 90);

				string newPass = Convert.ToString(a) + Convert.ToString(a1) + Convert.ToString(a2) + Convert.ToString(a3) + Convert.ToString(a4) + Convert.ToString(a5);

				sakila.Users users = null;

				using (sakila.HouseDBContext db = new sakila.HouseDBContext())
				{
					foreach (sakila.Users user in db.Users)
					{
						users = db.Users.Find(user.Iduser);
						if (EmailTxt.Text == user.Mail)
						{
							m.Body = "<h1>Пароль: " + newPass + "</h1>";
						}
					}
					users.Password = GetHashString(newPass);
					db.SaveChanges();
				}
				m.IsBodyHtml = true;
				SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
				smtp.Credentials = new NetworkCredential("cinema_maso@mail.ru", "vgmjRfJ415gwY1nC9SYd");
				smtp.EnableSsl = true;
				smtp.Send(m);

				MessageBox.Show("К Вам на почту было отправлено письмо с паролем! Пожалуйста, проверьте почту!");
				Authorization auto = new Authorization();
				auto.Show();
				this.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}
			
		}
	}
}
