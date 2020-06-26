using System.Collections.Generic;
using System.Text;
using System.IO;
using CodeGenerator.Datamodel;

namespace CodeGenerator.Generator
{
    public class InterfaceGenerator : BaseGenerator
    {

        // Constructor
        public InterfaceGenerator(StreamWriter outputFile, UML_BaseExtension classOrInterface) : base(outputFile, classOrInterface)
        {

        }


        /// <summary>
        /// Writes introductory line to the interface file.
        /// </summary>
        /// <param name="umlInterface"> Object containing information about the interface. </param>
        /// <returns></returns>
        public override StringBuilder writeBeginning_Specify(UML_BaseExtension umlInterface)
        {
            // Write beginning
            StringBuilder sb = new StringBuilder($"interface {umlInterface.name}");

            // Return StringBuilder
            return sb;
        }


        /// <summary>
        /// Fills in the attribute definition.
        /// </summary>
        /// <param name="umlAttribute"> Object containing information about the attribute. </param>
        /// <returns> Returns the string representing the UML_Attribute object. </returns>
        public override string writeAttribute_Specify(UML_Attribute umlAttribute)
        {

            // Overall attribute structure
            StringBuilder sb = new StringBuilder($"{umlAttribute.type} {umlAttribute.name}");

            // Append respective information
            if (umlAttribute.autoGetterSetterSpecified)
            {
                sb.Append(" { get; set; }");
            }
            else
            {
                sb.Append(";");
            }

            // Return built string
            return sb.ToString();
        }


        /// <summary>
        /// Fills in method body (or not).
        /// </summary>
        /// <param name="sb"> Current StringBuilder being used. </param>
        public override void writeMethod_Specify(StringBuilder sb)
        {
            sb.Append(";\n");
        }

    }
}
