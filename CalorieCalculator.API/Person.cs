using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API
{
    public class Person
    {
        public Calc.The_sex sex { get; set; }
        public PhysicalAttributes physicalAttribute { get; set; }
        public PersonalAttribute personalAttribute { get; set; }
        public Calculation GetCalculation()
        {
            if (sex == Calc.The_sex.Male)
                return new MaleCalculation(this);
            return new FemaleCalculation(this);
        }
    }
}
