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
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Login> logins { get; set; }


    }
}