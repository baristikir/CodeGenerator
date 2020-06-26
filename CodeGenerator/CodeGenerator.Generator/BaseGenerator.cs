using CodeGenerator.Datamodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Generator
{
    public class BaseGenerator
    {

        /// <summary> Variable to store the currently used file. </summary> 
        public StreamWriter outputFile;

        /// <summary> Variable which will contain the needed information for the class generator logic. </summary> 
        private UML_BaseExtension classOrInterface;
        private bool isClass;

        /// <summary> Tab needed for indentation purposes.</summary>
        public string structureTab = "\t";


        // Constructor
        public BaseGenerator(StreamWriter outputFile, UML_BaseExtension classOrInterface)
        {
            this.outputFile = outputFile;
            this.classOrInterface = classOrInterface;

            // Determine object type
            this.isClass = classOrInterface.GetType() == typeof(UML_Class) ? true : false;
        }



        /// <summary>
        /// Lays out the basic procedure when generating code.
        /// </summary>
        public void generateContent()
        {
            // Write beginning
            writeBeginning();

            // Write attributes
            writeAttributes();

            // Write methods
            writeMethods();

            // Ending line
            outputFile.WriteLine("}");
        }

        /// <summary> Writes the introductory line with the name matching what is found in the UML_Class / UML_Interface object. </summary>
        void writeBeginning()
        {
            // First line
            StringBuilder sb = writeBeginning_Specify(classOrInterface);

            // Last line
            sb.Append("\n{\n");

            // Write out built string
            outputFile.WriteLine(sb.ToString());
        }



        void writeAttributes()
        {

            // Extract attributes
            List<UML_Attribute> umlAttributes = classOrInterface.umlAttributes;

            // Comment in file
            if(umlAttributes.Count > 0) outputFile.WriteLine($"{structureTab}// Attributes");

            // Iterate over attribute list
            foreach (UML_Attribute umlAttribute in umlAttributes)
            {
                // Write attribute to file
                string attributeString = writeAttribute_Specify(umlAttribute);

                outputFile.WriteLine(structureTab + attributeString);

            }

            // Trailing line
            outputFile.WriteLine("");

        }

        

        /// <summary> Writes empty functions into a specified file with the name and parameters matching what is found in the passed list of methods that belong to the current class. </summary>
        void writeMethods()
        {

            // Extract methods
            List<UML_Method> umlMethods = classOrInterface.umlMethods;

            // Comment in file
            if(umlMethods.Count > 0) outputFile.WriteLine($"{structureTab}// Methods");

            // Iterate over method list
            foreach (UML_Method umlMethod in umlMethods)
            {
                StringBuilder sb = new StringBuilder(structureTab);

                // First line: acess modifier
                if (this.isClass && umlMethod.accessModifier != null) sb.Append($"{umlMethod.accessModifier} ");

                // First line: of extra keyword is set
                if (!umlMethod.extraKeyword.Equals("")) sb.Append($"{umlMethod.extraKeyword} ");

                // First line: append rest
                sb.Append($"{umlMethod.type} {umlMethod.name}(");

                // Append parameters
                if (umlMethod.parameters.Count > 0)
                {
                    foreach (UML_Parameter umlParameter in umlMethod.parameters)
                    {
                        sb.Append($"{umlParameter.parameterType} {umlParameter.parameterName}, ");
                    }
                    sb.Length -= 2;
                }

                // Close parantheses
                sb.Append(")");

                // Write body
                writeMethod_Specify(sb);

                // Write built string
                outputFile.WriteLine(sb.ToString());

            }
        }



        // To be overwritten in inheriting classes
        public virtual StringBuilder writeBeginning_Specify(UML_BaseExtension classOrInterface)
        {
            return new StringBuilder();
        }

        public virtual string writeAttribute_Specify(UML_Attribute umlAttribute)
        {
            return "";
        }

        public virtual void writeMethod_Specify(StringBuilder sb)
        {

        }

    }
}
