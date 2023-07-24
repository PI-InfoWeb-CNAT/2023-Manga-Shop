using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAppComercioEletronico.Models;

namespace WebAppComercioEletronico.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }


    }
}