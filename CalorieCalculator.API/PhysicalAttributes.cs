using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API
{
    public class PhysicalAttributes : Attribute
    {
       

        public string heightFeet { get; set; }
        public string heightInches { get; set; }
        public string weight { get; set; }
        public string age { get; set; }
        public PhysicalAttributes(string heightFeet, string heightInches, string weight, string age)
        {
            this.heightFeet = heightFeet;
            this.heightInches = heightInches;
            this.weight = weight;
            this.age = age;
        }
        public  override List<string> validate()
        {
            List<string> messages = new List<string>();
            if (!double.TryParse(heightFeet, out _))
            {
                messages.Add("Feet must be a numeric value.");
               
            }
            //Validate height (inches) is numeric value
            if (!double.TryParse(heightInches, out _))
            {
               messages.Add("Inches must be a numeric value.");
               
            }
            //Validate weight is numeric value
            if (!double.TryParse(weight, out _))
            {
                messages.Add("Weight must be a numeric value.");
               
            }
            //Validate age is numeric value
            if (!double.TryParse(age, out _))
            {
                messages.Add("Age must be a numeric value.");
               
            }
            if (!(Convert.ToDouble(heightFeet) >= 5))
            {
                messages.Add("Height has to be equal to or greater than 5 feet!");
               
            }
            return messages;
        }
        public double getHeightFeetInDouble()
        {
            return Convert.ToDouble(heightFeet);
        }
        public double getHeightInchesInDouble()
        {
            return Convert.ToDouble(heightInches);
        }
        public double getWeightInDouble()
        {
            return Convert.ToDouble(weight);
        }
        public double getAgeInDouble()
        {
            return Convert.ToDouble(age);
        }
    }
}
