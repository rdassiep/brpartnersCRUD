using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using brpartnersCRUD.Models;

namespace brpartnersCRUD.Data
{
    public class brpartnersCRUDContext : DbContext
    {
        public brpartnersCRUDContext (DbContextOptions<brpartnersCRUDContext> options)
            : base(options)
        {
        }

        public DbSet<brpartnersCRUD.Models.Client> Client { get; set; } = default!;
    }
}
