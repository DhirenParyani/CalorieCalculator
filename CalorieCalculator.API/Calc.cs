using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace CalorieCalculator.API
{
    public class Calc
    {
        public static string DISTANCE_FROM_IDEAL_WEIGHT { get; set; }
        public static string IDEAL_WEIGHT { get; set; }
        public static string CALORIES { get; set; }

        public static Calculation calculation;

        public static void Initialize()
        {
            DISTANCE_FROM_IDEAL_WEIGHT = "";
            IDEAL_WEIGHT = "";
            CALORIES = "";
        }

        public static void Calculate(string heightFeet, string heightInches, string weight, string age, The_sex sex)
        {
             Initialize();
            //Clear old results
            PhysicalAttributes physicalAttributes = new PhysicalAttributes(heightFeet, heightInches, weight, age);
            Person person = new Person();
            person.physicalAttribute = physicalAttributes;

            calculation = person.GetCalculation();


            /* Validate User Input: */
            //Validate height (feet) is numeric value
            List<String> validationMessages=physicalAttributes.validate();


            #region Input Validation
            if (validationMessages.Count > 0)
                throw new Exception(validationMessages[0]);
            #endregion Input Validation
            /*End validation*/

            #region Calories Calculation

            calculation.CaloriesConsumption();
            calculation.IdealWeight();
            #endregion Calories Calculation


            #region Calculate and display distance from ideal weight
            //Calculate and display distance from ideal weight
            calculation.DistanceFromIdealWeight();
            #endregion

        }

        public enum The_sex
        {
            Male,
            Female
        }

        public static void Save(string patientSsnPart1,string patientSsnPart2, string patientSsnPart3, string patientFirstName,  
                                   string patientLastName,  string heightFeet, string heightInches, string weight, string age)
        {
            PhysicalAttributes physicalAttributes = new PhysicalAttributes(heightFeet, heightInches, weight, age);
            PersonalAttribute personalAttributes = new PersonalAttribute(patientSsnPart1, patientSsnPart2, patientSsnPart3, patientFirstName, patientLastName);
            Person person = new Person();
            person.physicalAttribute = physicalAttributes;
            person.personalAttribute = personalAttributes;
            #region Patient Personal Input Data Validation
            List<string> personalAttributesValidation=personalAttributes.validate();
            foreach(string message in personalAttributesValidation)
            {
                Console.WriteLine(message);
            }

            #endregion Patient Personal Input Data Validation


            #region Patient General Data Validation
            List<string> physicalAttributesValidation = physicalAttributes.validate();
            foreach (string message in physicalAttributesValidation)
            {
                Console.WriteLine(message);
            }
            /*End validation*/


            #endregion Patient General Data Validation


            if (physicalAttributesValidation.Count>0 || personalAttributesValidation.Count>0)
            {
                throw new Exception("Invalid Output");
            }

            

            #region XML File Generation and Data Writing

           
            FileUtility fileUtility = new FileUtility();
            if (!fileUtility.LoadExistingXMLFile())
            {
                fileUtility.CreateNewtXMLFile(person);
            }
            else
            {
                fileUtility.AppendDataToExisitngXMLFile(person);
            }
            //Finally, save the xml to file
            fileUtility.SaveXMLFile();
            #endregion XML File Generation and Data Writing
        }


        public static string GetAssemblyDirectory()
        {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
        }


        public static string GetHistory()
        {
            return File.ReadAllText(GetAssemblyDirectory() + @"\PatientsHistory.xml");
        }



    }
}

