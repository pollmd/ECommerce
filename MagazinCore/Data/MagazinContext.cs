using MagazinCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagazinCore.Data
{
    public class MagazinCoreContext : IdentityDbContext
    {
        public MagazinCoreContext (DbContextOptions<MagazinCoreContext> options)
            : base(options)
        {
        }

        public DbSet<Produs> Produs { get; set; }

        public DbSet<Cos> Cos { get; set; }

        public DbSet<CosElemente> CosElemente { get; set; }
    }
}
