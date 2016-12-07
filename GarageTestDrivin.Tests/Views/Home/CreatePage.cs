using GarageTestDrivin.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.Extensions;
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Controls;
using TestStack.Seleno.PageObjects.Locators;

namespace GarageTestDrivin.Tests.Views.Home
{
    public class CreatePage : Page<CreateModel>
    {
        private const string ColorItemName = "Color";
        private const string RegNrItemName = "RegNr";
        private const string TypeItemName = "TypeId";
        private const string OwnerItemName = "OwnerId";

        public string InputColor
        {
            get
            {
                return Find.Element(By.Name(ColorItemName)).GetControlValueAs<string>();
            }
            set
            {
                Find.Element(By.Name(ColorItemName)).SendKeys(value);
            }
        }

        public string InputRegNr
        {
            get
            {
                return Find.Element(By.Name(RegNrItemName)).GetControlValueAs<string>();
            }
            set
            {
                Find.Element(By.Name(RegNrItemName)).SendKeys(value);
            }
        }

        public int InputTypeId
        {
            get
            {
                return Find.Element(By.Name(TypeItemName)).GetControlValueAs<int>();
            }
            set
            {
                Find.Element(By.Name(TypeItemName)).SendKeys(value.ToString());
            }
        }

        public int InputOwnerId
        {
            get
            {
                return Find.Element(By.Name(OwnerItemName)).GetControlValueAs<int>();
            }
            set
            {
                Find.Element(By.Name(OwnerItemName)).SendKeys(value.ToString());
            }
        }


        public void submit()
        {
            Find.Element(By.CssSelector("input[value='Create'][type='submit']")).Click();
        }

        public T Submit<T>(CreateModel createModel)
            where T : UiComponent, new()
        {
            Input.Model(createModel);
            return Navigate.To<T>(By.CssSelector("input[value='Create'][type='submit']"));
        }

        public void CreateANewVehicle()
        {
            this.InputColor = "Orange";
            this.InputOwnerId = 1;
            this.InputRegNr = "KUL137";
            this.InputTypeId = 1;
            this.submit();
        }
    }
}
