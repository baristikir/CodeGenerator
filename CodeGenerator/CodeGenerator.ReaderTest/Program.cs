using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using rd = CodeGenerator.Reader.Reader;
using dm = CodeGenerator.Datamodel.Datamodel;
using CodeGenerator.Datamodel;

namespace CodeGenerator.ReaderTest
{
    class Program
    {
        static void Main (string[] args)
        {
            readGraphml();
            Console.ReadKey(true);
        }

        // Test Method for creating datamodel
        static void readGraphml ()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string filepath = System.IO.Directory.GetParent(workingDirectory).Parent.FullName + "/Ressources/classdiagram.graphml";
            XDocument doc = XDocument.Load(filepath);
            XNamespace defaultNS = doc.Root.GetDefaultNamespace();
            XNamespace yNS = "http://www.yworks.com/xml/graphml";

            rd reader = new rd(filepath);
            dm datamodel = reader.createDatamodel();

            foreach (UML_Class modelItem in datamodel.umlClasses)
            {
                Console.WriteLine($"Class ID:{modelItem.id} \n Class Name: {modelItem.name}");
                foreach (var classAttribute in modelItem.umlAttributes)
                {
                    Console.WriteLine($"  Class Attribute -> Modifier: {classAttribute.accessModifier} , Name: {classAttribute.name} , Type: {classAttribute.type} ");
                }
                foreach (var classMethod in modelItem.umlMethods)
                {
                    Console.WriteLine($"  Class Method -> Name: {classMethod.name} , Type: {classMethod.type} ");
                }
            }

            foreach (UML_Interface interfaceItem in datamodel.umlInterfaces)
            {
                Console.WriteLine($"Interface ID: {interfaceItem.id} \n Interface Name: {interfaceItem.name}");
                foreach (var interfaceAttribute in interfaceItem.umlAttributes)
                {
                    Console.WriteLine($"   Interface Attribute -> Name: {interfaceAttribute.name} , Type: {interfaceAttribute.type}");
                }
                foreach (var interfaceMethod in interfaceItem.umlMethods)
                {
                    Console.WriteLine($"Interface Method -> Name: {interfaceMethod.name} , Type:{interfaceMethod.type}");
                }
            }
        }
    }
}
