using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Datamodel
{
    public class UML_Method : UML_Base
    {

        // "void", "int", etc.
        public string type { get; set; }

        // List to store method parameters, may be empty
        public List<UML_Parameter> parameters { get; set; }

        
        // Constructors
        public UML_Method()
        { 
            // Empty collection
            this.parameters = new List<UML_Parameter>();
        }

        public UML_Method(string id, string accessModifier, string type, string name, List<UML_Parameter> parameters, string extraKeyword = "") : base(id, accessModifier, name, extraKeyword)
        {
            this.type = type;

            // Check parameter
            this.parameters = parameters ?? new List<UML_Parameter>();
            
        }


        // Equals override
        public override bool Equals(object obj)
        {
            return this.accessModifier == ((UML_Method)obj).accessModifier 
                && this.name == ((UML_Method)obj)?.name 
                && this.type == ((UML_Method)obj)?.type
                && ( parameters == null && ((UML_Method)obj)?.parameters == null
                ||  parameters != null && ((UML_Method)obj)?.parameters != null 
                && parameters.SequenceEqual(((UML_Method)obj).parameters));
        }

        // GetHashCode override
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = parameters != null ? parameters.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (accessModifier != null ? accessModifier.GetHashCode() : 0 );
                hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (type != null ? type.GetHashCode() : 0);
                return hashCode;
            }
        }

    }
}
