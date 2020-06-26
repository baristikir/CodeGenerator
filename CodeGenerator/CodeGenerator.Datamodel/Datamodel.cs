using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Datamodel
{
    public class Datamodel
    {
        // List to store all classes found in the diagram
        public List<UML_Class> umlClasses { get; set; }

        // List to store all interfaces found in the diagram
        public List<UML_Interface> umlInterfaces { get; set; }


        // Constructors
        public Datamodel()
        {
            // Collection is now empty so enumerator can be used
            umlClasses = new List<UML_Class>();
            umlInterfaces = new List<UML_Interface>();
        }

        public Datamodel(List<UML_Class> umlClasses, List<UML_Interface> umlInterfaces)
        {
            this.umlClasses = umlClasses;
            this.umlInterfaces = umlInterfaces;
        }

    }
}
