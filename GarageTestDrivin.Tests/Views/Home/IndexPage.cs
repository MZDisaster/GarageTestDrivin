using GarageTestDrivin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Locators;

namespace GarageTestDrivin.Tests.Views.Home
{
    public class IndexPage : Page
    {
        public CreatePage gotoCreatePage()
        {
            return Navigate.To<CreatePage>(By.LinkText("Create New"));
        }

        public List<Vehicle> getTable()
        {
            var TRs = Find.Element(By.TagName("tbody")).FindElements(By.TagName("tr"));
            List<Vehicle> newv = new List<Vehicle>();
            foreach (var tr in TRs)
            {
                var TDs = tr.FindElements(By.TagName("td"));

                string link = TDs[4].FindElement(By.TagName("a")).GetAttribute("href");
                int routepos = link.LastIndexOf("/") + 1;
                int id = int.Parse(link.Substring(routepos));
                Vehicle v = new Vehicle() { Id = id, Owner = new Owner() { Name = TDs[0].Text }, Type = new VehicleType() { Name = TDs[1].Text }, Color = TDs[2].Text, RegNr = TDs[3].Text };

                newv.Add(v);
            }
            return newv;
        }

        public DeletePage Delete(int route)
        {
            return Navigate.To<DeletePage>(By.CssSelector("a[href='/Home/Delete/" + route + "']"));
        }

        public EditPage Edit(int route)
        {
            return Navigate.To<EditPage>(By.CssSelector("a[href='/Home/Edit/" + route + "']"));
        }

        public DetailsPage Details(int route)
        {
            return Navigate.To<DetailsPage>(By.CssSelector("a[href='/Home/Details/" + route + "']"));
        }
    }
}
