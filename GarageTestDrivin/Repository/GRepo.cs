using GarageTestDrivin.DataAccessLayer;
using GarageTestDrivin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GarageTestDrivin.Repository
{
    public class GRepo : GarageRepository
    {
        private IGarageContext db;

        public GRepo(IGarageContext context)
        {
            this.db = context;
        }

        public GRepo()
        {
            this.db = new GarageContext();
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return db.Vehicles.Include(v => v.Owner).Include(v => v.Type);
        }

        public IEnumerable<Owner> GetOwners()
        {
            return db.Owners;
        }

        public IEnumerable<VehicleType> GetVehicleTypes()
        {
            return db.VehicleTypes;
        }

        public Vehicle GetVehicle(int? id)
        {
            if (id == null)
                id = 1;
            return db.Vehicles.Find(id);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            db.Vehicles.Add(vehicle);
            db.SaveChanges();
        }

        public void EditVehicle(Vehicle vehicle)
        {
            Vehicle V = db.Vehicles.Find(vehicle.Id);
            V.RegNr = vehicle.RegNr;
            V.Color = vehicle.Color;
            V.OwnerId = vehicle.OwnerId;
            V.TypeId = vehicle.TypeId;
            V.Type = db.VehicleTypes.Find(vehicle.TypeId);
            V.Owner = db.Owners.Find(vehicle.OwnerId);
            //db.Entry(vehicle).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
        }
    }
}