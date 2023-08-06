using MangaShop.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaShop.Data
{
    public class BancoContext : DbContext
    {

        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        { }
        
        public DbSet<UserModel> Users { get; set; }

    }
}
