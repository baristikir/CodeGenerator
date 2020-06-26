using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Datamodel
{
    public class UML_BaseExtension : UML_Base
    {

        // List to store methods specified in the class diagram belonging to one class
        public List<UML_Method> umlMethods { get; set; }

        // List to store attributes specified in the class diagram belonging to one class
        public List<UML_Attribute> umlAttributes { get; set; }

        // Constructor
        public UML_BaseExtension() 
        {
            this.umlMethods = new List<UML_Method>();
            this.umlAttributes = new List<UML_Attribute>();
        }

        public UML_BaseExtension(string id, string accessModifier, string name, List<UML_Method> umlMethods, List<UML_Attribute> umlAttributes, string extraKeyword = "") : base(id, accessModifier, name, extraKeyword)
        {
            // Empty collection
            this.umlMethods = umlMethods ?? new List<UML_Method>();
            this.umlAttributes = umlAttributes ?? new List<UML_Attribute>();
        }
    }
}
