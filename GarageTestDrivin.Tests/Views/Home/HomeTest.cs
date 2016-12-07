using GarageTestDrivin.Controllers;
using GarageTestDrivin.Models;
using GarageTestDrivin.Tests.Models;
using GarageTestDrivin.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.PageObjects.Locators;

namespace GarageTestDrivin.Tests.Views.Home
{
    [TestClass]
    public class IndexTest
    {
        [TestMethod]
        public void Index_as_intended()
        {
            // Goto Index
            var Browser = BrowserHost.Instance.Application.Browser;

            var indexPage = BrowserHost.Instance.NavigateToInitialPage<HomeController, IndexPage>(x => x.Index());

            var Table = Browser.FindElement(By.TagName("Table")).Text;

            // Assert
            // Table exists with this header
            Assert.IsTrue(Table.Contains("Name Type Color RegNr"));

        }

        [TestMethod]
        public void Create_as_intended()
        {
            var Browser = BrowserHost.Instance.Application.Browser;
            Browser.Navigate().GoToUrl(BrowserHost.RootUrl + @"Home/Index");

            var indexPage = BrowserHost.Instance.NavigateToInitialPage<HomeController, IndexPage>(x => x.Index());

            var createPage = indexPage.gotoCreatePage();

            CreateModel createModel = new CreateModel()
            {
                Color = "Orange",
                OwnerId = 1,
                RegNr = "KUL137",
                TypeId = 1
            };

            // This
            /*
                createPage.InputColor = "Orange";
                createPage.InputOwnerId = 1;
                createPage.InputRegNr = "KUL137";
                createPage.InputTypeId = 1;
                createPage.submit();
             */
            // or This
            // createPage.CreateANewVehicle();
            // or This

            indexPage = createPage.Submit<IndexPage>(createModel);

            IEnumerable<Vehicle> VehicleFromcreateModel = indexPage.getTable().Where(v => v.RegNr == createModel.RegNr);


            // Assert
            // Create page creates a vehicle
            Assert.IsNotNull(VehicleFromcreateModel.First(v => v.RegNr == createModel.RegNr));
        }

        [TestMethod]
        public void Details_shows_details()
        {
            var Browser = BrowserHost.Instance.Application.Browser;
            Browser.Navigate().GoToUrl(BrowserHost.RootUrl + @"Home/Index");

            var indexPage = BrowserHost.Instance.NavigateToInitialPage<HomeController, IndexPage>(x => x.Index());
            var indexTable = indexPage.getTable();
            int id = indexTable.Where(v => v.RegNr == "KUL137").Select(v => v.Id).First();

            var detailsPage = indexPage.Details(id);

            DetailsModel detailsModel = detailsPage.CurrentModel();

            Assert.IsNotNull(detailsModel);
        }

        [TestMethod]
        public void Edit_as_intended()
        {
            var Browser = BrowserHost.Instance.Application.Browser;
            Browser.Navigate().GoToUrl(BrowserHost.RootUrl + @"Home/Index");

            var indexPage = BrowserHost.Instance.NavigateToInitialPage<HomeController, IndexPage>(x => x.Index());
            var indexTable = indexPage.getTable();
            int id = indexTable.Where(v => v.RegNr == "KUL137").Select(v => v.Id).First();

            var editPage = indexPage.Edit(id);


            EditModel editModel = editPage.CurrentModel();
            editModel.Color = "Green";

            indexPage = editPage.Submit<IndexPage>(editModel);

            Vehicle VehicleFromEditModel = indexPage.getTable().First(v => v.Id == id);

            // Assert
            // Test if color was changed
            Assert.IsTrue(VehicleFromEditModel.Color == "Green");
        }

        [TestMethod]
        public void Delete_as_intended()
        {
            var Browser = BrowserHost.Instance.Application.Browser;
            Browser.Navigate().GoToUrl(BrowserHost.RootUrl + @"Home/Index");

            var indexPage = BrowserHost.Instance.NavigateToInitialPage<HomeController, IndexPage>(x => x.Index());
            int id = indexPage.getTable().Where(v => v.RegNr == "KUL137").Select(v => v.Id).First();

            DeleteModel deleteModel = new DeleteModel() { Id = id };

            int oldCount = indexPage.getTable().Where(v => v.Id == deleteModel.Id).Count();

            var deletePage = indexPage.Delete(id);

            indexPage = deletePage.Submit<IndexPage>();

            IEnumerable<Vehicle> VehicleFromdeleteModel = indexPage.getTable().Where(v => v.Id == deleteModel.Id);

            int newCount = VehicleFromdeleteModel.Count();

            // Assert
            // Test if vehicle was deleted
            Assert.IsTrue(oldCount > newCount);
        }
    }
}
