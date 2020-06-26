using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Xunit;
using System.IO;
using System.Xml;
using CodeGenerator.Datamodel;
using CodeGenerator.Reader;

namespace CodeGenerator.ReaderUnitTest
{
    
    public class ReaderTest
    {
        // Test Komponente basierend auf die Struktur des alten Readers

        [Fact]
        public void checkInterface()
        {
            // Arrange
            string workingDirectory = Environment.CurrentDirectory;
            string filepath = Directory.GetParent(workingDirectory).Parent.FullName + "/Ressources/interfacediagram.graphml";
            string id = "n0";

            UML_Interface expectedInterface = new UML_Interface("Employee", id);

            // Act
            Reader.Reader instanceForDatamodel = new Reader.Reader(filepath);

            List<UML_Base> baseModel = instanceForDatamodel.AnalyzeNode();

            // Assert
            foreach (UML_Interface @interface in baseModel)
            {
                Assert.Equal(@interface.GetType(), expectedInterface.GetType());
            }

        }

        [Fact]
        public void checkClass()
        {
            // Arrange
            string workingDirectory = Environment.CurrentDirectory;
            string filepath = Directory.GetParent(workingDirectory).Parent.FullName + "/Ressources/classdiagram.graphml";

            UML_Class expectedClass = new UML_Class("Employee", "n0");

            // Act
            Reader.Reader instanceForDatamodel = new Reader.Reader(filepath);

            List<UML_Base> baseModel = instanceForDatamodel.AnalyzeNode();

            // Assert
            foreach (var @class in baseModel)
            {
                Assert.Equal(@class.GetType(), expectedClass.GetType());
            }
        }

        [Fact]
        public void CanGetValueOfAnalyzeNode()
        {
            // Arrange
            string workingDirectory = Environment.CurrentDirectory;
            string filepath = Directory.GetParent(workingDirectory).Parent.FullName +"/Ressources/classdiagram.graphml";

            List<UML_Base> expectedClassList = new List<UML_Base>();
            UML_Class expectedClass = new UML_Class("Employee", "n0");
            expectedClassList.Add(expectedClass);


            // Act
            XmlReader reader = new XmlTextReader(filepath);
            Reader.Reader instanceForDatamodel = new Reader.Reader(filepath);
            List<UML_Base> baseModelList = instanceForDatamodel.AnalyzeNode();


            // Assert
            Assert.Equal<UML_Base>(expectedClassList, baseModelList);
        }

        [Fact]
        public void CanGetMultipleValueOfAnalyzeNode()
        {
            // Arrange
            string workingDirectory = Environment.CurrentDirectory;
            string filepath = Directory.GetParent(workingDirectory).Parent.FullName + "/Ressources/classdiagram.graphml";
            List <UML_Base> classes = new List<UML_Base>();
            UML_Class expectedClass = new UML_Class("Employee", "n0");
            UML_Class expectedClass2 = new UML_Class("User", "n1");
            classes.Add(expectedClass);
            classes.Add(expectedClass2);

            // Act
            Reader.Reader instanceForDatamodel = new Reader.Reader(filepath);
            List<UML_Base> listOfClasses = instanceForDatamodel.AnalyzeNode();

            // Assert
            Assert.Equal(classes, listOfClasses);
        }

        //[Fact]
        //public void CanGetValueofAnalyzeNodeLabel()
        //{
        //    // Arange
        //    string className = "";
        //    string id = "n0";
        //    string filepath = Environment.CurrentDirectory + "/classdiagram.graphml";

        //    UML_Class ClassExpected = new UML_Class(className, id);
        //    ClassExpected.name = "Employee";

        //    // Act
        //    XmlReader reader = XmlReader.Create(filepath);
        //    Reader.Reader instanceForClass = new CodeGenerator.Reader.Reader(filepath);
        //    UML_Class ClassActual = instanceForClass.AnalyzeNodeLabel<UML_Class>("n0","name");

        //    // Assert
        //    Assert.Equal(ClassExpected ,ClassActual);
        //}

        [Fact]
        public void CanGetValueOfAnalyzeAttributeLabel()
        {
            // Arrange
            string workingDirectory = Environment.CurrentDirectory;
            string filepath = Directory.GetParent(workingDirectory).Parent.FullName + "/Ressources/classdiagram2.graphml";

            XDocument doc = XDocument.Load(filepath);
            XNamespace yns = "http://www.yworks.com/xml/graphml";

            List<string> attributeStringList = new List<string>();
            foreach (var attributeLabel in doc.Descendants(yns + "AttributeLabel"))
            {
                attributeStringList.Add(attributeLabel.Value);
            }

            List<UML_Attribute> expectedAttributes = new List<UML_Attribute>();
            UML_Attribute attribute1 = new UML_Attribute()
            {
                accessModifier = "public",
                name = "name",
                type = "string"
            };
            UML_Attribute attribute2 = new UML_Attribute()
            {
                accessModifier = "public",
                name = "age",
                type = "int"
            };
            expectedAttributes.Add(attribute1);
            expectedAttributes.Add(attribute2);


            // Act
            Reader.BaseReader instanceForAttributes = new Reader.BaseReader(filepath);
            List<UML_Attribute>classAttributes = new List<UML_Attribute>();
            List<UML_Attribute> attributeList = new List<UML_Attribute>();

            foreach (UML_Attribute item in classAttributes)
            {
                attributeList.Add(item);
            }

            // Assert
            Assert.Equal(expectedAttributes, attributeList);
        }

        //[Fact]
        //public void CanGetValueOfAnalyzeMethodLabel()
        //{
        //    // Arrange
        //    string filepath = Environment.CurrentDirectory + "/classdiagram.graphml";

        //    List<UML_Method> expectedMethods = new List<UML_Method>();
        //    UML_Method method1 = new UML_Method()
        //    {
        //        name = "getName",
        //        type = "String",
        //        parameters = new List<UML_Parameter>() { new UML_Parameter() { parameterName = "value", parameterType = "string" } }
        //    };
        //    UML_Method method2 = new UML_Method()
        //    {
        //        name = "getTitle",
        //        type = "String",
        //        parameters = null
        //    };
        //    UML_Method method3 = new UML_Method()
        //    {
        //        name = "getStaffNo",
        //        type = "Number",
        //        parameters = null
        //    };
        //    UML_Method method4 = new UML_Method()
        //    {
        //        name = "getRoom",
        //        type = "String",
        //        parameters = null
        //    };
        //    UML_Method method5 = new UML_Method()
        //    {
        //        name = "getPhone",
        //        parameters = null
        //    };

        //    expectedMethods.Add(method1);
        //    expectedMethods.Add(method2);
        //    expectedMethods.Add(method3);
        //    expectedMethods.Add(method4);
        //    expectedMethods.Add(method5);

        //    List<UML_Method> classMethods = new List<UML_Method>();

        //    // Act
        //    XmlReader reader = new XmlTextReader(filepath);
        //    Reader.Reader instanceForMethods = new Reader.Reader(filepath);
        //    classMethods = instanceForMethods.AnalyzeMethodLabel(reader);

        //    // Assert
        //    Assert.Equal(expectedMethods, classMethods);
        //}
    }
}
