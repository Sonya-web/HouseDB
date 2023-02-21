using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _1.sakila
{
    public partial class Users
    {
        public Users()
        {
            Booked = new HashSet<Booked>();
            Favourites = new HashSet<Favourites>();
            Realtor = new HashSet<Realtor>();
        }

        public int Iduser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public DateTime? DateOfBirthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public byte[] Photo { get; set; }

        public virtual ICollection<Booked> Booked { get; set; }
        public virtual ICollection<Favourites> Favourites { get; set; }
        public virtual ICollection<Realtor> Realtor { get; set; }

        public Users(string Login, string Password, string Email, string Name, string Surname, string Role, DateTime DateOfBirthday, byte[] Photo, string PhoneNumber)
		{
            this.Login = Login;
            this.Password = Password;
            this.Mail = Email;
            this.Name = Name;
            this.Surname = Surname;
            this.Role = Role;
            this.DateOfBirthday = DateOfBirthday;
            this.Photo = Photo;
            this.PhoneNumber = PhoneNumber;
		}
    }
}
