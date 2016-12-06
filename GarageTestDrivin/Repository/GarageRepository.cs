using GarageTestDrivin.DataAccessLayer;
using GarageTestDrivin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageTestDrivin.Repository
{
    public interface GarageRepository
    {

        IEnumerable<Vehicle> GetVehicles();
        IEnumerable<Owner> GetOwners();
        IEnumerable<VehicleType> GetVehicleTypes();
        Vehicle GetVehicle(int? id);

        void AddVehicle(Vehicle vehicle);
        void EditVehicle(Vehicle vehicle);
        void RemoveVehicle(Vehicle vehicle);

    }
}