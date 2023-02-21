using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _1.sakila
{
    public partial class HouseDBContext : DbContext
    {
        private static HouseDBContext _context;
        public HouseDBContext()
        {
        }

        public static HouseDBContext GetContext()
        {
            if (_context == null)
                _context = new HouseDBContext();
            return _context;
        }

        public HouseDBContext(DbContextOptions<HouseDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booked> Booked { get; set; }
        public virtual DbSet<Favourites> Favourites { get; set; }
        public virtual DbSet<Realtor> Realtor { get; set; }
        public virtual DbSet<Realty> Realty { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Term> Term { get; set; }
        public virtual DbSet<Typeofrealty> Typeofrealty { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;port=3306;Database=HouseDB;User ID=root;pwd=2181757640sonya;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booked>(entity =>
            {
                entity.HasKey(e => new { e.Idbooked, e.UserId, e.RealtyId })
                    .HasName("PRIMARY");

                entity.ToTable("booked");

                entity.HasIndex(e => e.RealtyId)
                    .HasName("fk_Booked_Realty1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_Booked_Users1_idx");

                entity.Property(e => e.Idbooked)
                    .HasColumnName("IDBooked")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.RealtyId).HasColumnName("RealtyID");

                entity.HasOne(d => d.Realty)
                    .WithMany(p => p.Booked)
                    .HasForeignKey(d => d.RealtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Booked_Realty1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Booked)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Booked_Users1");
            });

            modelBuilder.Entity<Favourites>(entity =>
            {
                entity.HasKey(e => new { e.Idfavourites, e.RealtyId, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("favourites");

                entity.HasIndex(e => e.RealtyId)
                    .HasName("fk_Favourites_Realty1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_Favourites_Users1_idx");

                entity.Property(e => e.Idfavourites)
                    .HasColumnName("IDFavourites")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RealtyId).HasColumnName("RealtyID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Realty)
                    .WithMany(p => p.Favourites)
                    .HasForeignKey(d => d.RealtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Favourites_Realty1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favourites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Favourites_Users1");
            });

            modelBuilder.Entity<Realtor>(entity =>
            {
                entity.HasKey(e => e.Idrealtor)
                    .HasName("PRIMARY");

                entity.ToTable("realtor");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_Realtor_Users1_idx");

                entity.Property(e => e.Idrealtor).HasColumnName("IDRealtor");

                entity.Property(e => e.Agency)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Realtor)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Realtor_Users1");
            });

            modelBuilder.Entity<Realty>(entity =>
            {
                entity.HasKey(e => e.Idrealty)
                    .HasName("PRIMARY");

                entity.ToTable("realty");

                entity.HasIndex(e => e.Idterm)
                    .HasName("IDTerm");

                entity.HasIndex(e => e.RealtorId)
                    .HasName("Realtor_idx");

                entity.HasIndex(e => e.StatusId)
                    .HasName("Status_idx");

                entity.HasIndex(e => e.TypeOfRealtyId)
                    .HasName("TypeOfRealty_idx");

                entity.Property(e => e.Idrealty).HasColumnName("IDRealty");

                entity.Property(e => e.FullAddress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FullDescription).HasColumnType("mediumtext");

                entity.Property(e => e.Idterm).HasColumnName("IDTerm");

                entity.Property(e => e.Metro)
                    .HasColumnName("metro")
                    .HasMaxLength(45);

                entity.Property(e => e.NameOfRc)
                    .HasColumnName("NameOfRC")
                    .HasMaxLength(100);

                entity.Property(e => e.Photo).HasColumnType("blob");

                entity.Property(e => e.PriceForSm).HasColumnName("PriceForSM");

                entity.Property(e => e.RealtorId).HasColumnName("RealtorID");

                entity.Property(e => e.ShortAddress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.TypeOfRealtyId).HasColumnName("TypeOfRealtyID");

                entity.Property(e => e.YearOfConstruction).HasColumnType("date");

                entity.HasOne(d => d.IdtermNavigation)
                    .WithMany(p => p.Realty)
                    .HasForeignKey(d => d.Idterm)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("realty_ibfk_1");

                entity.HasOne(d => d.Realtor)
                    .WithMany(p => p.Realty)
                    .HasForeignKey(d => d.RealtorId)
                    .HasConstraintName("Realtor");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Realty)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("Status");

                entity.HasOne(d => d.TypeOfRealty)
                    .WithMany(p => p.Realty)
                    .HasForeignKey(d => d.TypeOfRealtyId)
                    .HasConstraintName("TypeOfRealty");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.Idstatus)
                    .HasName("PRIMARY");

                entity.ToTable("status");

                entity.Property(e => e.Idstatus).HasColumnName("IDStatus");

                entity.Property(e => e.TypeOfStatus)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Term>(entity =>
            {
                entity.HasKey(e => e.Idterm)
                    .HasName("PRIMARY");

                entity.ToTable("term");

                entity.Property(e => e.Idterm).HasColumnName("IDTerm");

                entity.Property(e => e.TypeOfTerm)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Typeofrealty>(entity =>
            {
                entity.HasKey(e => e.IdtypeOfRealty)
                    .HasName("PRIMARY");

                entity.ToTable("typeofrealty");

                entity.Property(e => e.IdtypeOfRealty).HasColumnName("IDTypeOfRealty");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.DateOfBirthday).HasColumnType("date");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.PhoneNumber).HasMaxLength(13);

                entity.Property(e => e.Photo).HasColumnType("blob");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
