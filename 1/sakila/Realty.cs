using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _1.sakila
{
    public partial class Realty
    {
        public Realty()
        {
            Booked = new HashSet<Booked>();
            Favourites = new HashSet<Favourites>();
        }

        public int Idrealty { get; set; }
        public byte[] Photo { get; set; }
        public int TypeOfRealtyId { get; set; }
        public int NumberOfRooms { get; set; }
        public float? SquareMeters { get; set; }
        public string NameOfRc { get; set; }
        public string ShortAddress { get; set; }
        public string FullAddress { get; set; }
        public string Metro { get; set; }
        public int Price { get; set; }
        public int? PriceForSm { get; set; }
        public int TotalArea { get; set; }
        public int LivingArea { get; set; }
        public int? KitchenArea { get; set; }
        public int Floor { get; set; }
        public DateTime YearOfConstruction { get; set; }
        public string FullDescription { get; set; }
        public int RealtorId { get; set; }
        public int StatusId { get; set; }
        public int? UtilityBills { get; set; }
        public int? Idterm { get; set; }

        public virtual Term IdtermNavigation { get; set; }
        public virtual Realtor Realtor { get; set; }
        public virtual Status Status { get; set; }
        public virtual Typeofrealty TypeOfRealty { get; set; }
        public virtual ICollection<Booked> Booked { get; set; }
        public virtual ICollection<Favourites> Favourites { get; set; }

        public Realty(byte[] Photo, int TypeOfRealtyId, int NumberOfRooms, float? SquareMeters, string NameOfRc, string ShortAddress, string FullAddress, string Metro, int Price, int? PriceForSm, int TotalArea, int? KitchenArea, 
            int Floor, DateTime YearOfConstruction, string FullDescription, int StatusId, int? UtilityBills, int? Idterm)
        {
            this.Photo = Photo;
            this.TypeOfRealty = TypeOfRealty;
            this.NumberOfRooms = NumberOfRooms;
            this.SquareMeters = SquareMeters;
            this.NameOfRc = NameOfRc;
            this.ShortAddress = ShortAddress;
            this.FullAddress = FullAddress;
            this.Metro = Metro;
            this.Price = Price;
            this.PriceForSm = PriceForSm;
            this.TotalArea = TotalArea;
            this.KitchenArea = KitchenArea;
            this.Floor = Floor;
            this.YearOfConstruction = YearOfConstruction;
            this.FullDescription = FullDescription;
            this.StatusId = StatusId;
            this.UtilityBills = UtilityBills;
            this.Idterm = Idterm;
		}
    }
}
