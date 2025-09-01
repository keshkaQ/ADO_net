using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson_7_Linq_to_XML
{
    public class Program
    {
        static void CreateXMLDocument()
        {
            XDocument xmldoc = new XDocument(
                new XElement("computers",
                    new XElement("computer",
                        new XComment("Первый компьютер - Intel система"),
                        new XAttribute("Price", 800),
                        new XAttribute("Warranty", "2 years"),
                        new XElement("CPU",
                            new XAttribute("Name", "Intel Core i7-6700K"),
                            new XAttribute("GHz", 4.0) 
                        ),
                        new XElement("HDD",
                            new XAttribute("Name", "Samsung 850 PRO"),
                            new XAttribute("Size", 1.0)
                        ),
                        new XElement("RAM",
                            new XAttribute("Size", 16),
                            new XAttribute("Type", "DDR4")
                        )
                    ),
                    new XElement("computer",
                        new XComment("Второй компьютер - AMD система"),
                        new XAttribute("Price", 900),
                        new XAttribute("Warranty", "2 years"),
                        new XElement("CPU",
                            new XAttribute("Name", "AMD Ryzen 5 5600X"),
                            new XAttribute("GHz", 3.7) 
                        ),
                        new XElement("HDD",
                            new XAttribute("Name", "Transcend ESD400"),
                            new XAttribute("Size", 1.0)
                        ),
                        new XElement("RAM",
                            new XAttribute("Size", 16),
                            new XAttribute("Type", "DDR4")
                        )
                    )
                )
            );

            Console.WriteLine(xmldoc.ToString());
            string xmlFilePath = @"example.xml";
            xmldoc.Save(xmlFilePath);

            Console.WriteLine($"XML файл сохранен: {Path.GetFullPath(xmlFilePath)}");
        }

        static void ReadXMLDocument()
        {
            string xmlFilePath = @"example.xml";
            XDocument xmldoc = XDocument.Load(xmlFilePath);
            //var result = from c in xmldoc.Descendants(XName.Get("computer")) 
            //             where Convert.ToInt32(c.Attribute(XName.Get("Price")).Value) < 850
            //             select c;

            var result = xmldoc.Descendants("computer").Where(x => Convert.ToInt32(x.Attribute("Price").Value) < 850);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            } 
                
        }
        static void Main(string[] args)
        {
            ReadXMLDocument();
        }
    }
}