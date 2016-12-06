using GarageTestDrivin.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GarageTestDrivin.Models;

namespace GarageTestDrivin.Tests
{
    class TestGarageContext : IGarageContext
    {

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        public TestGarageContext()
        {
            this.Vehicles = new TestVehicleDbSet();
            this.Owners = new TestOwnerDbSet();
            this.VehicleTypes = new TestVehicleTypeDbSet();
        }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Vehicle vehicle)
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
