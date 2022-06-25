using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MagazinCore.Models;

namespace MagazinCore.Data
{
    public class MagazinCoreContext : DbContext
    {
        public MagazinCoreContext (DbContextOptions<MagazinCoreContext> options)
            : base(options)
        {
        }

        public DbSet<MagazinCore.Models.Produs> Produs { get; set; }

        public DbSet<MagazinCore.Models.Utilizatori> Utilizatori { get; set; }

        public DbSet<MagazinCore.Models.Cos> Cos { get; set; }

        public DbSet<MagazinCore.Models.CosElemente> CosElemente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         //  => optionsBuilder.UseNpgsql("Host=abul.db.elephantsql.com;Port=5432;Database=odkihpmm;Username=odkihpmm;Password=aQO6Uxbk6XXfxq46E9PfYBi-HWn_a6mP;");
         //  => optionsBuilder.UseNpgsql("Host=ec2-176-34-116-203.eu-west-1.compute.amazonaws.com;Port=5432;Database=dec0qf3f5d25p6;Username=vifwksyueayqkr;Password=d1a49cf50b29e95ea7e0918915faecf1aabb78052db69f0e5d380d6ed893c1c5");
         // => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");
           => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Port=5432;Username=postgres;Password=1");

    }
}
