using GarageTestDrivin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTestDrivin.Tests
{
    class TestOwnerDbSet : TestDbSet<Owner>
    {
        public override Owner Find(params object[] keyValues)
        {
            return this.SingleOrDefault(v => v.Id == (int)keyValues.Single());
        }
    }
}
