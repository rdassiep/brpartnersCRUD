using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using brpartnersCRUD.Models;

namespace brpartnersCRUD.Data
{
    public class BrpartnersCRUDContext : DbContext
    {
        public BrpartnersCRUDContext (DbContextOptions<BrpartnersCRUDContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Address>()
                .HasOne(f => f.Client)
                .WithMany(p => p.Addresses)
                .HasForeignKey(a => a.ClientId)
                .IsRequired(false);

            modelBuilder.Entity<Client>()
                .HasMany(f => f.Addresses);
 
        }
        public DbSet<brpartnersCRUD.Models.Address> Address { get; set; } = default!;
        public DbSet<brpartnersCRUD.Models.Client> Client { get; set; } = default!;
    }
}
