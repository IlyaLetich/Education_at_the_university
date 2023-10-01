using GoldTime.Models.DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;

namespace GoldTime.Models.DataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Watch> Watches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BasketWatches> BasketWatches { get; set; }
        public DbSet<ComparisonWatches> ComparisonWatches { get; set; }
        public DbSet<OrdersUser> OrdersUser { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=IlyaChernikin\SQLEXPRESS;Database=GoldenTime;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Watch>()
                    .HasMany(c => c.BasketWatches)
                    .WithMany(s => s.Watches)
                    .UsingEntity(j => j.ToTable("EnrollmentBasket"));
            modelBuilder.Entity<Watch>()
                    .HasMany(c => c.ComparisonWatches)
                    .WithMany(s => s.Watches)
                    .UsingEntity(j => j.ToTable("EnrollmentComparison"));
            modelBuilder.Entity<Order>()
                    .HasMany(c => c.OrdersUser)
                    .WithMany(s => s.Orders)
                    .UsingEntity(j => j.ToTable("EnrollmentOrders"));
        }
        public List<User> GetUserList()
        {
            using var context = new ApplicationContext();
            return context.Users.Include(x => x.WatchesBasket.Watches).Include(x => x.OrdersUser.Orders).Include(x => x.ComparisonWatches.Watches).ToList();
        }
    }
}
