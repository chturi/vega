using System;
using Microsoft.EntityFrameworkCore;
using vega.Models;

namespace vega.Persistence
{
    public class VegaDbContext : DbContext
    {
        
        public DbSet<Make> Makes {get; set;}
        public DbSet<Feature> Features {get; set;}

        public VegaDbContext(DbContextOptions<VegaDbContext> options) 
            : base (options)
        {
            
        }

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<VehicleFeature>().HasKey(vf =>
            new {vf.VehicleId, vf.FeatureId});


        }
    }
}