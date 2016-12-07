using GarageTestDrivin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Locators;
using TestStack.Seleno.Extensions;

namespace GarageTestDrivin.Tests.Views.Home
{
    public class DetailsPage : Page
    {
        public DetailsModel CurrentModel()
        {
            var DTs = Find.Elements(By.TagName("dt"));
            var DDs = Find.Elements(By.TagName("dd"));
            
            var e1 = DTs.GetEnumerator();
            var e2 = DDs.GetEnumerator();

            DetailsModel DModel = new DetailsModel();

            while(e1.MoveNext() && e2.MoveNext()){
                switch (e1.Current.Text)
                {
                    case "Name":
                        DModel.OwnerName = e2.Current.Text;
                        break;
                    case "Type":
                        DModel.TypeName = e2.Current.Text;
                        break;
                    case "Color":
                        DModel.Color = e2.Current.Text;
                        break;
                    case "RegNr":
                        DModel.RegNr = e2.Current.Text;
                        break;
                }
            }

            if(!string.IsNullOrEmpty(DModel.OwnerName) &&
                !string.IsNullOrEmpty(DModel.TypeName) &&
                !string.IsNullOrEmpty(DModel.Color) &&
                !string.IsNullOrEmpty(DModel.RegNr)
                )
            {
                return DModel;
            }

            return null;
        }
    }
}
