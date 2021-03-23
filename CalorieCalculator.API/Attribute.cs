using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API
{
    public abstract class Attribute
    {
        public abstract List<string> validate();
    }
}
