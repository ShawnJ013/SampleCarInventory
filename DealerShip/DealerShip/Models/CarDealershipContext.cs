using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DealerShip.Models
{
    public partial class CarDealershipContext : DbContext
    {
        public virtual DbSet<Vehicles> Vehicles { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=DESKTOP-H55PV2L\SQLEXPRESS_1;Database=CarDealership;Integrated Security=true;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Make)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasColumnType("string");
            });
        }
    }
}
