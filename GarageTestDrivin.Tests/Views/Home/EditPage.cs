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
    public class EditPage : Page<EditModel>
    {
        public EditModel CurrentModel()
        {
            string color = Find.Element(By.Name("Color")).GetControlValueAs<string>();
            string regNr = Find.Element(By.Name("RegNr")).GetControlValueAs<string>();
            int ownerId = Find.Element(By.Name("OwnerId")).GetControlValueAs<int>();
            int typeId = Find.Element(By.Name("TypeId")).GetControlValueAs<int>();

            if (!string.IsNullOrEmpty(color) || !string.IsNullOrEmpty(regNr) || ownerId != 0 || typeId != 0)
                return new EditModel()
                {
                    Color = color,
                    RegNr = regNr,
                    OwnerId = ownerId,
                    TypeId = typeId
                };
            else
                return null;
        }
        public T Submit<T>(EditModel editmodel)
           where T : UiComponent, new()
        {
            Input.Model(editmodel);
            return Navigate.To<T>(By.CssSelector("input[value='Save'][type='submit']"));
        }
    }
}
