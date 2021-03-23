using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CalorieCalculator.API
{
    class FileUtility
    {
        XmlDocument document { get; set; }

        public FileUtility()
        {
            document = new XmlDocument();
        }
        public bool LoadExistingXMLFile()
        {
            try
            {
                document.Load(Calc.GetAssemblyDirectory() + @"\PatientsHistory.xml");
            }
            catch (FileNotFoundException)
            {
                //If file not found, set fileCreated to false and continue
                return false;
            }
            return true;
        }

        public void CreateNewtXMLFile(Person person)
        {
            
            document.LoadXml(
                "<PatientsHistory>" +
                "<patient ssn=\"" + person.personalAttribute.getSSN() + "\"" + " firstName=\"" + person.personalAttribute.getPatientFirstName() + "\"" +
                " lastName=\"" + person.personalAttribute.getPatientLastName() + "\"" + ">" +
                "<measurement date=\"" + DateTime.Now + "\"" + ">" +
                "<height>" + ((Convert.ToInt32(person.physicalAttribute.heightFeet) * 12) + person.physicalAttribute.heightInches).ToString() + "</height>" +
                "<weight>" + person.physicalAttribute.weight + "</weight>" +
                "<age>" + person.physicalAttribute.age + "</age>" +
                "<dailyCaloriesRecommended>" +
               Calc.CALORIES +
                "</dailyCaloriesRecommended>" +
                "<idealBodyWeight>" +
                Calc.IDEAL_WEIGHT +
                "</idealBodyWeight>" +
                "<distanceFromIdealWeight>" +
                Calc.DISTANCE_FROM_IDEAL_WEIGHT +
                "</distanceFromIdealWeight>" +
                "</measurement>" +
                "</patient>" +
                "</PatientsHistory>");

           
        }
        public void AppendDataToExisitngXMLFile(Person person)
        {
            //Search for existing node for this patient
            XmlNode patientNode = null;
            foreach (XmlNode node in document.FirstChild.ChildNodes)
            {
                foreach (XmlAttribute attrib in node.Attributes)
                {
                    //We will use SSN to uniquely identify patient
                    if ((attrib.Name == "ssn") & (attrib.Value == person.personalAttribute.getSSN()))
                    {
                        patientNode = node;
                    }
                }
            }
            if (patientNode == null)
            {
                //just clone any patient node and use it for the new patient node
                XmlNode thisPatient =
                document.DocumentElement.FirstChild.CloneNode(false);
                thisPatient.Attributes["ssn"].Value = person.personalAttribute.getSSN();
                thisPatient.Attributes["firstName"].Value = person.personalAttribute.getPatientFirstName();
                thisPatient.Attributes["lastName"].Value = person.personalAttribute.getPatientLastName();
                XmlNode measurement = document.DocumentElement.FirstChild["measurement"].CloneNode(true);
                measurement.Attributes["date"].Value = DateTime.Now.ToString();
                measurement["height"].FirstChild.Value = ((Convert.ToInt32(person.physicalAttribute.heightFeet) * 12) + Convert.ToInt32(person.physicalAttribute.heightInches)).ToString();
                measurement["weight"].FirstChild.Value = person.physicalAttribute.weight;
                measurement["age"].FirstChild.Value = person.physicalAttribute.age;
                measurement["dailyCaloriesRecommended"].FirstChild.Value = Calc.CALORIES;
                measurement["idealBodyWeight"].FirstChild.Value = Calc.IDEAL_WEIGHT;
                measurement["distanceFromIdealWeight"].FirstChild.Value = Calc.DISTANCE_FROM_IDEAL_WEIGHT;
                thisPatient.AppendChild(measurement);
                document.FirstChild.AppendChild(thisPatient);
            }
            else
            {
                //If patient node found just clone any measurement
                //and use it for the new measurement
                XmlNode measurement = patientNode.FirstChild.CloneNode(true);
                measurement.Attributes["date"].Value = DateTime.Now.ToString();
                measurement["height"].FirstChild.Value = ((Convert.ToInt32(person.physicalAttribute.heightFeet) * 12) + Convert.ToInt32(person.physicalAttribute.heightInches)).ToString();
                measurement["weight"].FirstChild.Value = person.physicalAttribute.weight;
                measurement["age"].FirstChild.Value = person.physicalAttribute.age;
                measurement["dailyCaloriesRecommended"].FirstChild.Value = Calc.CALORIES;
                measurement["idealBodyWeight"].FirstChild.Value = Calc.IDEAL_WEIGHT;
                measurement["distanceFromIdealWeight"].FirstChild.Value = Calc.DISTANCE_FROM_IDEAL_WEIGHT;
                patientNode.AppendChild(measurement);
            }
        }

        public void SaveXMLFile()
        {
            document.Save(Calc.GetAssemblyDirectory() + @"\PatientsHistory.xml");
        }
    }
}
