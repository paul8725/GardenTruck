using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GardenTruck.Models;
using Microsoft.EntityFrameworkCore;

namespace GardenTruck.Data
{
    public class GardenTruckContext : DbContext
    {
        public GardenTruckContext (DbContextOptions<GardenTruckContext> options)
            : base(options)
        {
        }

        public DbSet<Flowers> Flowers { get; set; }

        public DbSet<Seeds> Seeds { get; set; }

        public DbSet<Feedback> Feedback { get; set; }
    }
}
