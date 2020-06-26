using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Datamodel
{
    public class UML_Parameter
    {

        public string parameterName;

        public string parameterType;


        // Constructors
        public UML_Parameter()
        {

        }

        public UML_Parameter(string parameterType, string parameterName)
        {
            this.parameterName = parameterName;
            this.parameterType = parameterType;
        }

        public override bool Equals(object obj)
        {
            return parameterName == ((UML_Parameter)obj)?.parameterName &&
                   parameterType == ((UML_Parameter)obj)?.parameterType;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = parameterName != null ? parameterName.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (parameterType != null ? parameterType.GetHashCode() : 0);
                return hashCode;
            }
        }

    }
}
