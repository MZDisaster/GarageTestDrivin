using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GarageTestDrivin;
using GarageTestDrivin.Controllers;
using GarageTestDrivin.Models;
using GarageTestDrivin.Repository;
using Telerik.JustMock;
using System.Reflection;

namespace GarageTestDrivin.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Repo_returns_vehicles()
        {
            // Arrange
            Vehicle[] vehicleList = new Vehicle[] { 
                    new Vehicle{ Id = 1, TypeId = 1, OwnerId = 1, Color = "Red", RegNr = "ABC123"},
                    new Vehicle{ Id = 2, TypeId = 1, OwnerId = 2, Color = "Blue", RegNr = "ABC234"}
            };
            var Repo = Mock.Create<GarageRepository>();
            Mock.Arrange(() => Repo.GetVehicles()).
                Returns(
                    vehicleList
                ).MustBeCalled();

            // Act
            HomeController controller = new HomeController(Repo);
            ViewResult result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<Vehicle>;

            // Assert
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Count(), vehicleList.Count());

            int i = 0;

            foreach (Vehicle v in vehicleList)
            {
                foreach (PropertyInfo p in v.GetType().GetProperties())
                {
                    Assert.AreEqual(p.GetValue(model.ToList()[i]), p.GetValue(v));
                }

                i += 1;
            }
        }

        [TestMethod]
        public void Details_returns_vehicle()
        {
            // Arrange
            Vehicle vehicle = new Vehicle { Id = 1, TypeId = 1, OwnerId = 2, Color = "Blue", RegNr = "ABC234" };
            var Repo = Mock.Create<GarageRepository>();
            Mock.Arrange(() => Repo.GetVehicle(1)).
                Returns(
                    vehicle
                ).MustBeCalled();

            // Act
            HomeController controller = new HomeController(Repo);
            ViewResult result = controller.Details(1) as ViewResult;

            var model = result.Model as Vehicle;

            // Assert
            Assert.IsNotNull(model);

            foreach (PropertyInfo p in model.GetType().GetProperties())
            {
                Assert.AreEqual(p.GetValue(model), p.GetValue(vehicle));
            }
        }

        [TestMethod]
        public void Create_creats_vehicle()
        {
            // Arrange
            Vehicle vehicle = new Vehicle { Id = 1, TypeId = 1, OwnerId = 1, Color = "Blue", RegNr = "ABC234" };
            IList<Vehicle> vehiclesList = new List<Vehicle>();

            var Repo = Mock.Create<GarageRepository>();
            Mock.Arrange(() => Repo.AddVehicle(vehicle)).DoInstead((Vehicle v) => vehiclesList.Add(v));

            // Act
            HomeController controller = new HomeController(Repo);
            controller.Create(vehicle);

            //var model = result.Model as Vehicle;

            // Assert
            Assert.IsTrue(vehiclesList.Contains(vehicle));

        }

        [TestMethod]
        public void Edit_edits_vehicle()
        {
            // Arrange
            Vehicle vehicle = new Vehicle { Id = 1, TypeId = 1, OwnerId = 1, Color = "Blue", RegNr = "ABC234" };
            Vehicle[] vehiclesList = new Vehicle[] { vehicle };

            Vehicle editedvehicle = new Vehicle { Id = 1, TypeId = 1, OwnerId = 1, Color = "Green", RegNr = "ABC234" };

            var Repo = Mock.Create<GarageRepository>();
            Mock.Arrange(() => Repo.EditVehicle(editedvehicle)).DoInstead((Vehicle v) => vehiclesList[0] = v);

            // Act
            HomeController controller = new HomeController(Repo);
            controller.Edit(editedvehicle);

            //var model = result.Model as Vehicle;

            // Assert
            Assert.IsTrue(vehiclesList.Contains(editedvehicle));

        }

        [TestMethod]
        public void Delete_deletes_vehicle()
        {
            // Arrange
            Vehicle vehicle = new Vehicle { Id = 1, TypeId = 1, OwnerId = 1, Color = "Blue", RegNr = "ABC234" };
            IList<Vehicle> vehiclesList = new List<Vehicle>();
            vehiclesList.Add(vehicle);

            var Repo = Mock.Create<GarageRepository>();
            Mock.Arrange(() => Repo.RemoveVehicle(vehicle)).DoInstead((Vehicle v) => vehiclesList.Remove(v));
            Mock.Arrange(() => Repo.GetVehicle(1)).Returns(vehicle);
            // Act
            HomeController controller = new HomeController(Repo);
            controller.DeleteConfirmed(1);

            //var model = result.Model as Vehicle;

            // Assert
            Assert.IsFalse(vehiclesList.Contains(vehicle));

        }

    }
}
