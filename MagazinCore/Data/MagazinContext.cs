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
    }
}
