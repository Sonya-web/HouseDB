using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _1.sakila
{
    public partial class Favourites
    {
        public int Idfavourites { get; set; }
        public int RealtyId { get; set; }
        public int UserId { get; set; }

        public virtual Realty Realty { get; set; }
        public virtual Users User { get; set; }
    }
}
