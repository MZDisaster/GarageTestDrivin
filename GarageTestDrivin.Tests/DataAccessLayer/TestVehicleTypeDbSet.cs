using GarageTestDrivin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTestDrivin.Tests
{
    class TestVehicleTypeDbSet : TestDbSet<VehicleType>
    {
        public override VehicleType Find(params object[] keyValues)
        {
            return this.SingleOrDefault(v => v.Id == (int)keyValues.Single());
        }
    }
}
