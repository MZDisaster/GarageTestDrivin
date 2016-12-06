using GarageTestDrivin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GarageTestDrivin.DataAccessLayer
{
    public class GarageContext : DbContext, IGarageContext
    {
        public DbSet<Owner> Owners { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        public GarageContext() : base ("DefaultConnection")
        {

        }

        public void MarkAsModified(Vehicle vehicle)
        {
            Entry(vehicle).State = EntityState.Modified;
        }
    }
}