using System;
using System.IO;
using CommonInterfaces;
using CodeGenerator.Datamodel;
using dm = CodeGenerator.Datamodel;
using DMMIException = Exceptions.DatamodelMissingInformationException;
using DMMCException = Exceptions.DatamodelMissingContentException;


namespace CodeGenerator.Generator
{
    public class Generator : IGenerator
    {
        
        /// <summary> Created files go here. </summary>
        public string filePath { get; set; }

        /// <summary> Datamodel object containing information about everything found in the class diagram.</summary>
        public dm.Datamodel dml { get; set; }


        // Constructor
        public Generator(string filePath, dm.Datamodel dml)
        {
            this.filePath = filePath;
            this.dml = dml;
        }
        

        /// <summary>
        /// Writes ".cs" files to the specified file path according to the passed Datamodel.
        /// </summary>
        /// <returns>Nothing.</returns>
        public bool generateCode()
        {

            // Check datamodel
            if (isDataModelComplete())
            {

                // Iterate over classes
                foreach (UML_Class umlClass in dml.umlClasses)
                {
                    // Create new file
                    using (StreamWriter classFile = new StreamWriter(filePath + "\\" + umlClass.name + ".cs"))
                    {

                        // Create ClassGenerator object
                        ClassGenerator cGen = new ClassGenerator(classFile, umlClass);

                        // Generate class
                        cGen.generateContent();

                    }
                }

                // Iterate over interfaces
                foreach (UML_Interface umlInterface in dml.umlInterfaces)
                {
                    // Create new file
                    using (StreamWriter interfaceFile = new StreamWriter(filePath + "\\" + umlInterface.name + ".cs"))
                    {

                        // Create InterfaceGenerator object
                        InterfaceGenerator iGen = new InterfaceGenerator(interfaceFile, umlInterface);

                        // Generate class
                        iGen.generateContent();

                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Validates the datamodels' completeness.
        /// </summary>
        /// <returns></returns>
        private bool isDataModelComplete()
        {

            // Classes: Check top level
            if (dml.umlClasses == null)
            {
                throw new DMMIException("Class list is null!");
            }
            else
            {
                // Check classes
                checkClasses();
            }

            // Interfaces: Check top level
            if(dml.umlInterfaces == null)
            {
                throw new DMMIException("Interface list is null!");
            }
            else
            {
                // Check interfaces
                checkInterfaces();
            }


            // If we made is this far
            return true;
        }

        /// <summary>
        /// Checks object for existence of basic information.
        /// </summary>
        /// <param name="baseExt"> UML_Class or UML_Interface object. </param>
        private void checkBase(dm.UML_BaseExtension baseExt)
        {

            // access modifier
            if (baseExt.GetType() == typeof(UML_Class) && baseExt.accessModifier == "")
            {
                throw new DMMCException($"'accessModifier' of class {baseExt} is \"\"");
            }

            // name
            if (baseExt.name == "")
            {
                throw new DMMCException($"'name' of class {baseExt} is \"\"");
            }

            // attributes
            if (baseExt.umlAttributes == null)
            {
                throw new DMMIException($"'umlAttributes' of class {baseExt} is null!");
            }

            // methods
            if (baseExt.umlMethods == null)
            {
                throw new DMMIException($"'umlMethods' of class {baseExt} is null!");
            }

        }

        /// <summary>
        /// Checks UML_Class object for class-specific information.
        /// </summary>
        private void checkClasses()
        {
            // Iterate over classes
            foreach (UML_Class someClass in dml.umlClasses)
            {

                // Check access modifier, name, attributes, methods
                checkBase(someClass);

                // implementedInterfaces
                if(someClass.implementedInterfaces == null)
                {
                    throw new DMMIException($"'implementedInterfaces' of class {someClass} is null!");
                }
            }
        }


        /// <summary>
        /// Checks UML_Interface object for class-specific information.
        /// </summary>
        private void checkInterfaces()
        {
            // Iterate over classes
            foreach (UML_Interface someInterface in dml.umlInterfaces)
            {

                // Check access modifier, name, attributes, methods
                checkBase(someInterface);

            }

        }

        

    }
}
