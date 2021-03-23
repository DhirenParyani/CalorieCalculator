using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API
{
    class FemaleCalculation : Calculation
    {
        public FemaleCalculation(Person person)
        {
            this.person = person;
        }
        public override void CaloriesConsumption()
        {
            Calc.CALORIES = (655
                + (4.3 * this.person.physicalAttribute.getWeightInDouble())
                + (4.7 * ((this.person.physicalAttribute.getHeightFeetInDouble() * 12))
                + this.person.physicalAttribute.getHeightInchesInDouble())
                - (4.7 * this.person.physicalAttribute.getAgeInDouble())).ToString();
          
            //Calculate ideal body weight
            
        }

        
        public override void IdealWeight()
        {
            Calc.IDEAL_WEIGHT = ((45.5 +
            (2.3 * (((this.person.physicalAttribute.getHeightFeetInDouble() - 5) * 12)
            + this.person.physicalAttribute.getHeightInchesInDouble()))) * 2.2046).ToString();
        }
    }
}
