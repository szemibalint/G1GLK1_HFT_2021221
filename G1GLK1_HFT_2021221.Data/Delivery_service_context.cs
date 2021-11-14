using G1GLK1_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Data
{
    public class Delivery_service_context : DbContext
    {
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Consumer> Consumers { get; set; }
        public Delivery_service_context()
        {
            Database.EnsureCreated();
        }
        public Delivery_service_context(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True; MultipleActiveResultSets=True;");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasData(new Restaurant { RestaurantId = 1, Location = "Raday  Street" , Cuisine = "Chinese" , NameOfRestaurant = "Best 'Chicken' in Town"});

            modelBuilder.Entity<Order>()
                .HasData(new Order { OrderId = 1,  ConsumerId = 1 , RestaurantId = 1,  Food = "Chicken Curry with rice" , Price = 1769,   TimeOfOrder = new DateTime(2021,11,14,16,23,00)});

            modelBuilder.Entity<Consumer>()
                .HasData(new Consumer { ConsumerId = 1 ,  FirstName = "Rock" , LastName = "Lee" , Address = "Kossuth Square 45"});
        }
    }
}
