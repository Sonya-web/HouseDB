using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _1.sakila
{
    public partial class Status
    {
        public Status()
        {
            Realty = new HashSet<Realty>();
        }

        public int Idstatus { get; set; }
        public string TypeOfStatus { get; set; }

        public virtual ICollection<Realty> Realty { get; set; }
    }
}
