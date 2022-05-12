using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreSqlDb.Models
{
    public class RiverDatabaseContext : DbContext
    {
        public RiverDatabaseContext(DbContextOptions<RiverDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<DotNetCoreSqlDb.Models.River> River { get; set; }
    }
}
