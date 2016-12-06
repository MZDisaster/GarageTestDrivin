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
            Browser.Navigate().GoToUrl(BrowserHost.RootUrl + @"Home/Index");
            
            var Table = Browser.FindElement(By.TagName("Table")).Text;

            // Assert
            // Table contains proper header and needed buttons for functionality
            Assert.IsTrue(Table.Contains("Name Name Color RegNr") && Table.Contains("Edit") && Table.Contains("Details") && Table.Contains("Delete"));


        }

        [TestMethod]
        public void Create_as_intended()
        {
            var Browser = BrowserHost.Instance.Application.Browser;
            Browser.Navigate().GoToUrl(BrowserHost.RootUrl + @"Home/Index");

            var CreateButton = Browser.FindElement(By.LinkText("Create New"));
            CreateButton.Click();

            var ColorInput = Browser.FindElement(By.Name("Color"));
            ColorInput.SendKeys("Orange");

            var RegNrInput = Browser.FindElement(By.Name("RegNr"));
            RegNrInput.SendKeys("KUL137");

            var TypeIdSelect = Browser.FindElement(By.Name("TypeId"));
            

            var OwnerIdSelect = Browser.FindElement(By.Name("OwnerId"));


            var SubmittButton = By.jQuery("input[value='Create'][type='submit']");
        }
    }
}
