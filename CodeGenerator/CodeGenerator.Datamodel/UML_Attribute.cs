using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Datamodel
{
    public class UML_Attribute : UML_Base
    {

        // "void", "int", etc.
        public string type { get; set; }

        // Getter, setter
        public bool autoGetterSetterSpecified { get; set; }

        // Constructors
        public UML_Attribute()
        {

        }

        public UML_Attribute(object attribute)
        {
            string attributeName = attribute.ToString();
            this.name = attributeName;
        }

        public UML_Attribute(string id, string accessModifier, string type, string name, string extraKeyword = "", bool autoGetterSetter = false) : base(id, accessModifier, name, extraKeyword)
        {
            this.type = type;
            this.autoGetterSetterSpecified = autoGetterSetter;
        }

        // Equals override
        public override bool Equals(object obj)
        {
            return this.accessModifier == ((UML_Attribute)obj).accessModifier && this.name == ((UML_Attribute)obj).name && this.type == ((UML_Attribute)obj).type;
        }
    }
}
