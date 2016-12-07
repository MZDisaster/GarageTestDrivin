using GarageTestDrivin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Locators;

namespace GarageTestDrivin.Tests.Views.Home
{
    public class DeletePage : Page<DeleteModel>
    {
        public T SubmitWithModel<T>(DeleteModel deleteModel)
            where T : UiComponent, new()
        {
            Input.Model(deleteModel);
            return Navigate.To<T>(By.CssSelector("input[value='Delete'][type='submit']"));
        }

        public T Submit<T>()
            where T : UiComponent, new()
        {
            return Navigate.To<T>(By.CssSelector("input[value='Delete'][type='submit']"));
        }
    }
}
