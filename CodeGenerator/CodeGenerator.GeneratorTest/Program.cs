using System.Collections.Generic;
using gen = CodeGenerator.Generator;
using dm = CodeGenerator.Datamodel;
using System;

namespace CodeGenerator.GeneratorTest
{
    class Program
    {
        static void Main(string[] args)
        {

            generatorTest();

        }


        ////////////////// TEST
        public static void generatorTest()
        {

            // 4 attributes
            dm.UML_Attribute att1 = new dm.UML_Attribute("a1", "public", "int", "testNumber");
            dm.UML_Attribute att2 = new dm.UML_Attribute("a2", "private", "double", "testDouble");
            dm.UML_Attribute att3 = new dm.UML_Attribute("a3", "private", "string", "rasr33", "const");
            dm.UML_Attribute att4 = new dm.UML_Attribute("a4", "public", "char", "rjojo32", "static", true);

            // 4 methods
            dm.UML_Parameter param1 = new dm.UML_Parameter("int", "testInt");
            dm.UML_Parameter param2 = new dm.UML_Parameter("double", "testDouble");
            dm.UML_Parameter param3 = new dm.UML_Parameter("string", "testString");
            dm.UML_Parameter param4 = new dm.UML_Parameter("char", "testChar");

            dm.UML_Method method1 = new dm.UML_Method("m1", "public", "void", "testMethod1", new List<dm.UML_Parameter>() { param1 });
            dm.UML_Method method2 = new dm.UML_Method("m2", "public", "void", "testMethod2", new List<dm.UML_Parameter>() { param1, param2 });
            dm.UML_Method method3 = new dm.UML_Method("m3", "public", "void", "testMethod3", new List<dm.UML_Parameter>() { param1, param2, param3, param4 });

            // 2 interfaces
            dm.UML_Interface interface1 = new dm.UML_Interface("i1", "interface1", new List<dm.UML_Attribute>() {att1, att3 }, new List<dm.UML_Method>() {});
            dm.UML_Interface interface2 = new dm.UML_Interface("i2", "interface2", new List<dm.UML_Attribute>() { att2, att4 }, new List<dm.UML_Method>() { method2, method3 });

            // 3 classes
            dm.UML_Class class1 = new dm.UML_Class("c1", "public", "class1", new List<dm.UML_Attribute>() { att1 }, new List<dm.UML_Method>() { method1 }, new List<dm.UML_Interface>() { interface1 }, "");
            dm.UML_Class class2 = new dm.UML_Class("c2", "private", "class2", new List<dm.UML_Attribute>() { att1, att2, att3, att4 }, new List<dm.UML_Method>() { }, new List<dm.UML_Interface>(), "static", class1);
            dm.UML_Class class3 = new dm.UML_Class("c3", "public", "class3", new List<dm.UML_Attribute>() { att1, att2, att3, att4 }, new List<dm.UML_Method>() { method1, method2, method3 }, new List<dm.UML_Interface>() { interface1, interface2 }, "", class1);


            // Bring it all together
            dm.Datamodel dml = new dm.Datamodel
            {
                umlClasses = new List<dm.UML_Class>() { class1, class2, class3 },
                umlInterfaces = new List<dm.UML_Interface>() { interface1, interface2 }
            };

            // Create generator object
            string outputPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GeneratorTestFiles";
            System.IO.Directory.CreateDirectory(outputPath);
            gen.Generator gen = new gen.Generator(outputPath, dml);
            gen.generateCode();

        }
    }
}
