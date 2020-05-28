using System;
using Microsoft.EntityFrameworkCore;
using vega.Models;

namespace vega.Persistence
{
    public class VegaDbContext : DbContext
    {

        public VegaDbContext(DbContextOptions<VegaDbContext> options) 
            : base (options)
        {
            
        }

        public DbSet<Make> Makes {get; set;}
        public DbSet<Feature> Features {get; set;}

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}