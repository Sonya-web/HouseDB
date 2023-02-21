using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _1.sakila
{
    public partial class Realtor
    {
        public Realtor()
        {
            Realty = new HashSet<Realty>();
        }

        public int Idrealtor { get; set; }
        public string Agency { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Realty> Realty { get; set; }
        
        public Realtor(string Agency, int UserId)
		{
            this.Agency = Agency;
            this.UserId = UserId;
		}
    }
}
