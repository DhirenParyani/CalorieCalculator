using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API
{
    class MaleCalculation : Calculation
    {
        public MaleCalculation(Person person)
        {
            this.person = person;
        }
        public override void CaloriesConsumption()
        {
            Calc.CALORIES = ((66
                + (6.3 * this.person.physicalAttribute.getWeightInDouble())
                + (12.9 * (this.person.physicalAttribute.getHeightFeetInDouble() * 12) + this.person.physicalAttribute.getHeightInchesInDouble())
                - (6.8 * this.person.physicalAttribute.getAgeInDouble())).ToString());
        }

       

        public override void IdealWeight()
        {
            Calc.IDEAL_WEIGHT = ((50 +
              (2.3 * (((this.person.physicalAttribute.getHeightFeetInDouble() - 5) * 12)
              + this.person.physicalAttribute.getHeightInchesInDouble()))) * 2.2046).ToString();
        }
    }
}
