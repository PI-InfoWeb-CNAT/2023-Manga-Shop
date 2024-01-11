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


    }
}
