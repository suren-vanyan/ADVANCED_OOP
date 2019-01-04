using System;
using System.IO;
using System.Xml;

namespace XML_Configuration.AdditionalTasks
{
    class Program
    {
        static void CreateXMLFile(XmlDocument xmlDoc)
        {
            //Создайте.xml файл, который соответствовал бы следующим требованиям: 
            //· имя файла: TelephoneBook.xml
            //· корневой элемент: “MyContacts” 
            //· тег “Contact”, и в нем должно быть записано имя контакта и атрибут “TelephoneNumber” со значением номера телефона. 

            var xmlDeclar = xmlDoc.CreateXmlDeclaration("1.0", "ISO-8859-1", null);
            xmlDoc.AppendChild(xmlDeclar);
            XmlNode xmlElement = xmlDoc.CreateNode(XmlNodeType.Element, "MyContacts", null);
            xmlDoc.AppendChild(xmlElement);
            XmlElement contactElement = xmlDoc.CreateElement("Contact");
            XmlAttribute xmlAttribute = xmlDoc.CreateAttribute("TelephoneNumber");

            XmlText attributeText = xmlDoc.CreateTextNode("098464743");
            xmlAttribute.AppendChild(attributeText);
            contactElement.Attributes.Append(xmlAttribute);

            XmlText contactText = xmlDoc.CreateTextNode("Suren Vanyan");
            contactElement.AppendChild(contactText);

            xmlElement.AppendChild(contactElement);


            xmlDoc.Save("TelephoneBook.xml");
        }

        static void ReadAllInformationXML(XmlDocument xmlDoc)
        {
            // Task2. Create an application that displays all the information about the specified .xml file.
             FileStream fileStream = File.Open("TelephoneBook.xml", FileMode.Open);
            XmlTextReader textReader = new XmlTextReader(fileStream);
            while (textReader.Read())
            {
                if (textReader.HasAttributes)
                {
                    if (textReader.Name == "Contact")
                    {
                        Console.WriteLine($"{textReader.NodeType}:{textReader.Name}");
                        Console.WriteLine($"{textReader.GetAttribute("TelephoneNumber")}");
                    }
                }
            }

            textReader.Close();

        }

        static void Main(string[] args)
        {        
            XmlDocument xmlDoc = new XmlDocument();
            //CreateXMLFile(xmlDoc);
            ReadAllInformationXML(xmlDoc);


        }
    }
}
