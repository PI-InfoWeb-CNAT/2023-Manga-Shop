using MangaShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace MangaShop.Data
{
    public class BancoContext : DbContext
    {

        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserCartItem> UserCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCartItem>()
                .HasKey(uc => new { uc.UserId, uc.ProductId });

            modelBuilder.Entity<UserCartItem>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.Carrinho)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserCartItem>()
                .HasOne(uc => uc.Product)
                .WithMany()
                .HasForeignKey(uc => uc.ProductId);
        }

    }
}