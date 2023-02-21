using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _1.sakila
{
    public partial class Term
    {
        public Term()
        {
            Realty = new HashSet<Realty>();
        }

        public int Idterm { get; set; }
        public string TypeOfTerm { get; set; }

        public virtual ICollection<Realty> Realty { get; set; }
    }
}
