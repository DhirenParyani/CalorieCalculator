using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API
{
    public abstract class Calculation
    {
        public Person person { get; set; }
        public abstract void CaloriesConsumption();
        public abstract void IdealWeight();
        public void DistanceFromIdealWeight()
        {
            Calc.DISTANCE_FROM_IDEAL_WEIGHT = (person.physicalAttribute.getWeightInDouble() - Convert.ToDouble(Calc.IDEAL_WEIGHT)).ToString();
        }

        

    }
}
