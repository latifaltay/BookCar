using BookCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookCar.Persistence.Context
{
    public class BookCarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-VCQ63AG; initial Catalog = BookCarDb; integrated Security = true; TrustServerCertificate = true ");
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;; initial Catalog = BookCarDb; integrated Security = true; TrustServerCertificate = true ");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TagCloud> TagClouds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RentACar> RentACars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.PickUpLocation)
                .WithMany(x => x.PickUpReservation)
                .HasForeignKey(x => x.PickUpLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.DropOffLocation)
                .WithMany(x => x.DropOffReservation)
                .HasForeignKey(x => x.DropOffLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

    }
}
