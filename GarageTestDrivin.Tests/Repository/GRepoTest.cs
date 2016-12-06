using GarageTestDrivin.Models;
using GarageTestDrivin.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace GarageTestDrivin.Tests.Repository
{
    [TestClass]
    public class GRepoTest
    {
        [TestMethod]
        public void GetVehicles_should_return_ienumberable_Of_Vehicle()
        {
            // arrange
            IEnumerable<Vehicle> Vehicles = ObjectCreator.Vehicles();

            var context = new TestGarageContext();
            context.Vehicles.AddRange(Vehicles);

            var repo = new GRepo(context);
            
            // act
            var result = repo.GetVehicles() as IEnumerable<Vehicle>;

            //assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Vehicle>));
            Assert.AreEqual(Vehicles.Count(), result.Count());

            IEnumerator<Vehicle> e1 = Vehicles.GetEnumerator();
            IEnumerator<Vehicle> e2 = result.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
            {
                Assert.AreEqual(e1.Current, e2.Current);
            }
        }

        [TestMethod]
        public void GetOwners_should_return_ienumberable_Of_Owner()
        {
            // arrange
            IEnumerable<Owner> Owners = ObjectCreator.Owners();

            var context = new TestGarageContext();
            context.Owners.AddRange(Owners);

            var repo = new GRepo(context);

            // act
            var result = repo.GetOwners() as IEnumerable<Owner>;

            //assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Owner>));
            Assert.AreEqual(Owners.Count(), result.Count());

            IEnumerator<Owner> e1 = Owners.GetEnumerator();
            IEnumerator<Owner> e2 = result.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
            {
                Assert.AreEqual(e1.Current, e2.Current);
            }
        }

        [TestMethod]
        public void GetVehicleTypes_should_return_ienumberable_Of_VehicleType()
        {
            // arrange
            IEnumerable<VehicleType> VehicleTypes = ObjectCreator.VehicleTypes();

            var context = new TestGarageContext();
            context.VehicleTypes.AddRange(VehicleTypes);

            var repo = new GRepo(context);

            // act
            var result = repo.GetVehicleTypes() as IEnumerable<VehicleType>;

            //assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<VehicleType>));
            Assert.AreEqual(VehicleTypes.Count(), result.Count());

            IEnumerator<VehicleType> e1 = VehicleTypes.GetEnumerator();
            IEnumerator<VehicleType> e2 = result.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
            {
                Assert.AreEqual(e1.Current, e2.Current);
            }
        }

        [TestMethod]
        public void GetVehicle_should_return_object_of_vehicle()
        {
            // arrange
            IEnumerable<Vehicle> Vehicles = ObjectCreator.Vehicles();

            var context = new TestGarageContext();
            context.Vehicles.AddRange(Vehicles);

            var repo = new GRepo(context);

            // act
            var result = repo.GetVehicle(1) as Vehicle;

            //assert

            Assert.IsInstanceOfType(result, typeof(Vehicle));

            Assert.IsTrue(Vehicles.Contains(result));

            var testvehicle = Vehicles.SingleOrDefault(v => v.Id == result.Id);
            foreach (PropertyInfo p in result.GetType().GetProperties())
            {
                Assert.AreEqual(p.GetValue(result), p.GetValue(testvehicle));
            }
        }

        [TestMethod]
        public void AddVehicle_shuold_add_vehicle()
        {
            // arrange
            Vehicle TestVehicle = new Vehicle { Id = 1, Color = "Red", RegNr = "ABH234", OwnerId = 1, TypeId = 1 };

            var context = new TestGarageContext();
            var repo = new GRepo(context);

            // Act
            int oldCount = repo.GetVehicles().Count();
            repo.AddVehicle(TestVehicle);
            var result = repo.GetVehicle(1) as Vehicle;

            // Assert

            //Count has changed
            Assert.AreNotEqual(oldCount, repo.GetVehicles().Count());

            //Count increased by only 1
            Assert.AreEqual((oldCount + 1), repo.GetVehicles().Count());

            //Vehicle added is the same as the vehicle returned from the repository
            Assert.AreEqual(TestVehicle, result);
        }

        [TestMethod]
        public void EditVehicle_shuold_edit_vehicle()
        {
            // arrange
            Vehicle OldTestVehicle = new Vehicle { Id = 1, Color = "Red", RegNr = "ABH234", OwnerId = 1, TypeId = 1 };
            Vehicle TestVehicle = new Vehicle { Id = 1, Color = "Red", RegNr = "ABH234", OwnerId = 1, TypeId = 1 };
            Vehicle TestVehicleEdit = new Vehicle { Id = 1, Color = "Green", RegNr = "ABH234", OwnerId = 1, TypeId = 1 };

            var context = new TestGarageContext();
            var repo = new GRepo(context);
            repo.AddVehicle(TestVehicle);

            // Act            
            repo.EditVehicle(TestVehicleEdit);

            var result = repo.GetVehicle(1) as Vehicle;

            // Assert

            // Vehicle was changed
            Assert.AreNotEqual(OldTestVehicle.Color, TestVehicle.Color);

            // Vehicle color was changed to green
            Assert.AreEqual(TestVehicle.Color, "Green");

            // TestVehicle is the same as the result
            Assert.AreEqual(result, TestVehicle);
        }

        [TestMethod]
        public void RemoveVehicle_shuold_remove_vehicle()
        {
            // arrange
            Vehicle TestVehicle = new Vehicle { Id = 1, Color = "Red", RegNr = "ABH234", OwnerId = 1, TypeId = 1 };

            var context = new TestGarageContext();
            var repo = new GRepo(context);
            repo.AddVehicle(TestVehicle);

            // Act
            int OldCount = repo.GetVehicles().Count();
            repo.RemoveVehicle(TestVehicle);

            var result = repo.GetVehicles() as IEnumerable<Vehicle>;

            // Assert

            // Repository was changed
            Assert.AreNotEqual(OldCount, result.Count());

            // Count decresed by only 1
            Assert.AreEqual((OldCount - 1), result.Count());

            // TestVehicle doesn't exist in the result
            Assert.IsFalse(result.Contains(TestVehicle));
        }
    }
}
