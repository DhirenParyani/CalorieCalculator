using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API
{
    public class PersonalAttribute : Attribute
    {
        public PersonalAttribute(string patientSsnPart1, string patientSsnPart2, string patientSsnPart3, string patientFirstName, string patientLastName)
        {
            this.patientSsnPart1 = patientSsnPart1;
            this.patientSsnPart2 = patientSsnPart2;
            this.patientSsnPart3 = patientSsnPart3;
            this.patientFirstName = patientFirstName;
            this.patientLastName = patientLastName;
        }

        public string patientSsnPart1 { get; set; }
        public string patientSsnPart2 { get; set; }
        public string patientSsnPart3 { get; set; }
        public string patientFirstName { get; set; }
        public string patientLastName { get; set; }
        public override List<string> validate()
        {
            List<string> messages = new List<string>();
            
            if ((!int.TryParse(patientSsnPart1, out _)) |
                (!int.TryParse(patientSsnPart2, out _)) |
                (!int.TryParse(patientSsnPart3, out _)))
            {
                messages.Add("You must enter valid SSN.");
                
            }
            if (patientFirstName.Trim().Length < 1)
            {
                messages.Add("You must enter patient’s first name.");
                
            }
            if (patientLastName.Trim().Length < 1)
            {
                messages.Add("You must enter patient’s last name.");
                
            }

            return messages;
        }

        public string getSSN()
        {
            return patientSsnPart1 + "-" + patientSsnPart2 + "-" + patientSsnPart3;
        }

        public string getPatientFirstName()
        {
            return patientFirstName;
        }

        public string getPatientLastName()
        {
            return patientLastName;
        }
    }
}
