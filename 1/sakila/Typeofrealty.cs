using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _1.sakila
{
    public partial class Typeofrealty
    {
        public Typeofrealty()
        {
            Realty = new HashSet<Realty>();
        }

        public int IdtypeOfRealty { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Realty> Realty { get; set; }
    }
}
