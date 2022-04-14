using CarParts.Domain.Entities;
using CarParts.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Persistence.Context
{
    public class CarPartsDbContext : DbContext
    {
        public CarPartsDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppRole> AppRoles => this.Set<AppRole>();
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();
        public DbSet<AppUserAdress> AppUserAdresses => this.Set<AppUserAdress>();
        public DbSet<AppUserPhone> AppUserPhones => this.Set<AppUserPhone>();
        public DbSet<Category> Categories => this.Set<Category>();
        public DbSet<Cart> Carts => this.Set<Cart>();
        public DbSet<CartItem> CartItems => this.Set<CartItem>();
        public DbSet<Order> Orders => this.Set<Order>();
        public DbSet<OrderDetails> OrderDetails => this.Set<OrderDetails>();
        public DbSet<Product> Products => this.Set<Product>();
        public DbSet<SellerList> SellerLists => this.Set<SellerList>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SellerListConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}
