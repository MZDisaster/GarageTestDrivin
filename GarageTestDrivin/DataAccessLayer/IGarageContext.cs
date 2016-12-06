using GarageTestDrivin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GarageTestDrivin.DataAccessLayer
{
    public interface IGarageContext : IDisposable
    {
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<Owner> Owners { get; set; }
        DbSet<VehicleType> VehicleTypes { get; set; }
        int SaveChanges();
        void MarkAsModified(Vehicle vehicle);    
    }
}