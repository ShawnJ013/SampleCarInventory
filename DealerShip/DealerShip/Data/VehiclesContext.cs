using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerShip.Data
{
    public class VehiclesContext : DbContext

    {
        public VehiclesContext(DbContextOptions<VehiclesContext> options) 
            
            : base(options)        

        {

        }

        public DbSet<DealerShip.Models.Vehicles> Vehicles { get; set; }
    }
}
