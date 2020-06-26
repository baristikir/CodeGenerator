using System;
using System.Collections.Generic;
using System.Linq;
using CodeGenerator.Datamodel;
using System.Xml.Linq;
using CommonInterfaces;
using IUSE = Exceptions.InvalidUMLShapesException;

/* TODO:
 * 
 * **AnalyzeNodeLabel** : Method structure & structure for storing data  [DONE ✔]
 *  --> Interface or Class Detection [DONE ✔]
 *      --> Unit Test for Interface [DONE ✔]
 *      --> Unit Test for Class     [DONE ✔]
 *  --> Add new *Id* property for *UML_Class* objects  [DONE ✔]
 * 
 * **AnalyzeAttributeLabel** : Method structure & structure for storing data [DONE ✔]
 * 
 * **AnalyzeMethodLabel** : Method structure & structure for storing data [DONE ✔]
 *  --> fix Problem: method.type => IndexOutOfRangeException [DONE ✔]
 *  --> parameters: **getParameter()** method refactor the logic & structure [DONE ✔]
 *      --> possible Exceptions: IndexOutOfRangeException => **getMethod()** -> *UML_Method* -> *object*.type  [DONE ✔]
 * 
 * **AnalyzeInheritance** : <data id="">  [DONE ✔]
 *  --> Every Class object need id [DONE ✔]
 *  --> Parents : Class or Interface? [DONE ✔]
 * 
 */

namespace CodeGenerator.Reader
{
    public class Reader : IReader
    {
        #region Members
        public string filepath { get; set; }
        #endregion

        #region Constructor
        public Reader(string filepath)
        {
            this.filepath = filepath;
        }
        #endregion

        /// <summary>
        /// Main method creating the whole datamodel
        /// </summary>
        /// <param name="filepath"> Path of the file which was received from Controller Component</param>
        /// <returns></returns>
        public Datamodel.Datamodel createDatamodel()
        {
                Datamodel.Datamodel datamodel = null;
                datamodel = new Datamodel.Datamodel();
                List<UML_Base> baseModel = AnalyzeNode();
                foreach (var item in baseModel)
                {
                    if (item.GetType() == typeof(UML_Class) && baseModel != null)
                    {
                        datamodel.umlClasses.Add((UML_Class)item);
                    }

                    if (item.GetType() == typeof(UML_Interface) && baseModel != null)
                    {
                        datamodel.umlInterfaces.Add((UML_Interface)item);
                    }
                }

                return datamodel;
        }

        /// <summary>
        /// Collecting all informations of the graphml file and storing relevant data into dictionaries.
        /// </summary>
        /// <returns> List with all existing Objects </returns>
        public List<UML_Base> AnalyzeNode()
        {
            // Load Graphml file
            XDocument doc = XDocument.Load(this.filepath);

            // Default Namespace for xml-tags without y:
            XNamespace ns = doc.Root.GetDefaultNamespace();

            // Specific Namespace for xml-tags with y: at the beginning of the name
            XNamespace yns = "http://www.yworks.com/xml/graphml";

            // Storing all relevant data to create UML_Class and UML_Interface objects
            Dictionary<string, List<string>> keys = new Dictionary<string, List<string>>();
            foreach (var node in doc.Descendants(ns + "node"))
            {
                // Dictionary Key are Id Values for each node
                keys[node.Attribute("id").Value] = new List<string>();

                // For each Id getting data about NodeLabel,AttributeLabel and MthodLabel
                // Relevant Data to create UML_Class/UML_Interface & UML_Attribute & UML_Method objects
                foreach (var nodelabel in node.Descendants(yns + "NodeLabel"))
                {
                    keys[node.Attribute("id").Value].Add(nodelabel.Value);
                    keys[node.Attribute("id").Value].Add(nodelabel.Attribute("fontStyle").Value);
                    foreach (var attributeLabel in node.Descendants(yns + "AttributeLabel"))
                    {
                        keys[node.Attribute("id").Value].Add(attributeLabel.Value);
                    }
                    foreach (var methodLabel in node.Descendants(yns + "MethodLabel"))
                    {
                        keys[node.Attribute("id").Value].Add(methodLabel.Value);
                    }
                }
            }

            // check for valid uml notation
            checkGrapml(doc, keys);

            // Storing relevant data about inheritance
            Dictionary<string, List<string>> inheritance = new Dictionary<string, List<string>>();
            foreach (var source in doc.Descendants(ns + "edge"))
            {
                inheritance[source.Attribute("source").Value] = new List<string>();
                inheritance[source.Attribute("source").Value].Add(source.Attribute("target").Value);

                foreach (var whiteDelta in source.Descendants(yns + "Arrows"))
                {
                    inheritance[source.Attribute("source").Value].Add(whiteDelta.Attribute("target").Value);
                }
                foreach (var line in source.Descendants(yns + "LineStyle"))
                {
                    inheritance[source.Attribute("source").Value].Add(line.Attribute("type").Value);
                }

            }

            // List of Object creation based on dictionary which collected all relevant data
            List<UML_Base> baseModelList = getModel(keys);

            // Checking for existing Inheritance based on dictionary which collected all relevant inheritance data
            checkInheritance(baseModelList, inheritance);

            return baseModelList;
        }

        /// <summary>
        /// Putting together all existing Class and Interface Objects into one List
        /// </summary>
        /// <param name="dict"> Dictionary stored information about names,attributes and methods for each ID</param>
        /// <returns> List with all objects </returns>
        List<UML_Base> getModel(Dictionary<string, List<string>> dict)//where T : UML_Base
        {
            List<UML_Base> baseModels = new List<UML_Base>();
            foreach (var entry in dict)
            {
                var baseModel = AnalyzeNodeLabel<UML_Base>(entry.Key, entry.Value[0], entry.Value[1], entry.Value[2], entry.Value[3]);
                if (baseModel.GetType() == typeof(UML_Class))
                {
                    baseModels.Add(baseModel);
                }
                if (baseModel.GetType() == typeof(UML_Interface))
                {
                    baseModels.Add(baseModel);
                }
            }
            return baseModels;
        }

        /// <summary>
        /// Data about existing inheritance will be compared with objects of the list if they are existing and simultaneously to determine the correct object
        /// </summary>
        /// <param name="baseList"> Containing all parsed Classes and Interfaces </param>
        /// <param name="inheritanceDict"> Containing data about inheritance read from the .graphml file </param>
        /// <returns> Inheritance is available or not </returns>
        bool checkInheritance(List<UML_Base> baseList, Dictionary<string, List<string>> inheritanceDict)
        {
            bool inheritanceChecker = false;
            foreach (var item in inheritanceDict)
            {
                if (item.Value.Count > 1)
                {
                    if (item.Value[1] == "white_delta" && item.Value[2] == "line")
                    {
                        inheritanceChecker = true;
                        getInheritance(baseList, item.Key, item.Value[0]);
                    }
                }
            }
            return inheritanceChecker;
        }

        /// <summary>
        /// Providing the correct relationship between inherited objects 
        /// </summary>
        /// <param name="baseModelList"> Containing all parsed Classes and Interfaces</param>
        /// <param name="source"> Soruce Id from graphml file </param>
        /// <param name="target"> Target Id from graphml file </param>
        void getInheritance(List<UML_Base> baseModelList, string source, string target)
        {
            var sourceId = source;
            var targetId = target;

            if (baseModelList.Find(x => x.id == targetId).GetType() == typeof(UML_Interface))
            {
                UML_Class classParent = (UML_Class)baseModelList.Find(y => y.id == sourceId);
                UML_Interface implementedInterface = (UML_Interface)baseModelList.Find(y => y.id == targetId);
                List<UML_Interface> implementedInterfaceList = new List<UML_Interface>();
                implementedInterfaceList.Add(implementedInterface);
                classParent.implementedInterfaces = implementedInterfaceList;
            }
            if (baseModelList.Find(x => x.id == targetId).GetType() == typeof(UML_Class))
            {
                UML_Class classParent = (UML_Class)baseModelList.Find(y => y.id == sourceId);
                UML_Class implementedClass = (UML_Class)baseModelList.Find(y => y.id == targetId);
                classParent.parent = implementedClass;
            }
        }

        /// <summary>
        /// Main Method for determine each existing Element if they are a Class or a Interface
        /// </summary>
        /// <typeparam name="T"> Generic - Either UML_Class Object or UML_Interface Object </typeparam>
        /// <param name="nodeId"> Containing information about the associated id values from yEd </param>
        /// <param name="name"> Containing Information about the names of the Class or Interface </param>
        /// <param name="fontStyle"> Containing Information about the font style </param>
        /// <param name="attributes"> Containing information about existing attributes of each object</param>
        /// <param name="methods"> Containign information about existing methods of each object </param>
        /// <returns> UML_Class object or UML_Interface object </returns>
        public T AnalyzeNodeLabel<T>(string nodeId, string name, string fontStyle, string attributes, string methods) where T : CodeGenerator.Datamodel.UML_Base
        {
            string modifierPublic = "public";
            string modifierPrivate = "private";
            string modifierProtected = "protected";

            string abstractKey = "abstract";

            if (checkModelInterface(name))
            {
                string interfaceName = name.Replace("<<interface>>", "").Replace("\n", "");

                if (name.StartsWith("+"))
                {
                    UML_Interface interfaceModel = new UML_Interface(interfaceName, nodeId);
                    interfaceModel.accessModifier = modifierPublic;
                    interfaceModel.umlAttributes = AnalyzeAttributeLabel(attributes);
                    return (T)Convert.ChangeType(interfaceModel, typeof(UML_Interface));
                }
                if (name.StartsWith("-"))
                {
                    UML_Interface interfaceModel = new UML_Interface(interfaceName, nodeId);
                    interfaceModel.accessModifier = modifierPrivate;
                    interfaceModel.umlAttributes = AnalyzeAttributeLabel(attributes);
                    return (T)Convert.ChangeType(interfaceModel, typeof(UML_Interface));
                }
                if (name.StartsWith("#"))
                {
                    UML_Interface interfaceModel = new UML_Interface(interfaceName, nodeId);
                    interfaceModel.accessModifier = modifierProtected;
                    interfaceModel.umlAttributes = AnalyzeAttributeLabel(attributes);
                    return (T)Convert.ChangeType(interfaceModel, typeof(UML_Interface));
                }
                else
                {
                    UML_Interface interfaceModel = new UML_Interface(interfaceName, nodeId);
                    interfaceModel.umlAttributes = AnalyzeAttributeLabel(attributes);
                    interfaceModel.umlMethods = AnalyzeMethodLabel(methods);
                    return (T)Convert.ChangeType(interfaceModel, typeof(UML_Interface));
                }
            }
            if (checkModelClass(name))
            {
                if (name.StartsWith("+"))
                {
                    UML_Class classModel = new UML_Class(name, nodeId);
                    if (checkAbstractClass(fontStyle))
                    {
                        classModel.extraKeyword = abstractKey;
                    }
                    classModel.accessModifier = modifierPublic;
                    classModel.umlAttributes = AnalyzeAttributeLabel(attributes);
                    return (T)Convert.ChangeType(classModel, typeof(UML_Class));
                }
                if (name.StartsWith("-"))
                {
                    UML_Class classModel = new UML_Class(name, nodeId);
                    if (checkAbstractClass(fontStyle))
                    {
                        classModel.extraKeyword = abstractKey;
                    }
                    classModel.accessModifier = modifierPrivate;
                    classModel.umlAttributes = AnalyzeAttributeLabel(attributes);
                    return (T)Convert.ChangeType(classModel, typeof(UML_Class));
                }
                if (name.StartsWith("#"))
                {
                    UML_Class classModel = new UML_Class(name, nodeId);
                    if (checkAbstractClass(fontStyle))
                    {
                        classModel.extraKeyword = abstractKey;
                    }
                    classModel.accessModifier = modifierProtected;
                    classModel.umlAttributes = AnalyzeAttributeLabel(attributes);
                    return (T)Convert.ChangeType(classModel, typeof(UML_Class));
                }
                else
                {
                    UML_Class classModel = new UML_Class(name, nodeId);
                    if (checkAbstractClass(fontStyle))
                    {
                        classModel.extraKeyword = abstractKey;
                    }
                    classModel.umlAttributes = AnalyzeAttributeLabel(attributes);
                    classModel.umlMethods = AnalyzeMethodLabel(methods);
                    return (T)Convert.ChangeType(classModel, typeof(UML_Class));
                }
            }
            return null;
        }

        /// <summary>
        ///  Method for checking Graphml shape usage. If they are not equal to UML Shapes an exception will be thrown
        /// </summary>
        /// <param name="document"> Containing Graphml document </param>
        /// <param name="baseDict"> Containing all elements and values from graphml document </param>
        /// <returns> UML Classdiagram notation valid or not </returns>
        bool checkGrapml(XDocument document, Dictionary<string,List<string>> baseDict)
        {
            XNamespace yns = "http://www.yworks.com/xml/graphml";
            var documentValues = document.Descendants(yns + "UMLClassNode").ToList().Count;
            if (documentValues == baseDict.Count)
            {
                return true;
            }

            if (documentValues != baseDict.Count)
            {
                throw new IUSE("invalid uml shape");
            }
            return false;
        }

        // Check if existing Node is a Interface to craete UML_Interface Object
        bool checkModelInterface(string name)
        {
            if (name.Contains("<<interface>>") || name.Contains("&lt;&lt;interface&gt;&gt;") || name.Contains("interface") || name.StartsWith("I") && name.Substring(0, 1).ToUpper().Equals(name))
            {
                return true;
            }

            return false;
        }

        // Check if existing Node is a Class to craete UML_Class Object
        bool checkModelClass(string name)
        {
            if (name != null && !name.Contains("&lt;&lt;interface&gt;&gt;") || !name.Contains("interface") || !name.StartsWith("I") && !name.Substring(0, 1).ToUpper().Equals(name))
            {
                return true;
            }

            return false;
        }

        // Check if class is abstract or not
        bool checkAbstractClass(string fontStyle)
        {
            if (fontStyle == "italic")
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Main Method for handling parsed data about existing Attributes
        /// </summary>
        /// <param name="attr"> Containing information about the attributes </param>
        /// <returns> Datamodel valid List of all Attributes for each Class or Interface </returns>
        public List<UML_Attribute> AnalyzeAttributeLabel (string attr)
        {
            BaseReader reader = new BaseReader(this.filepath);

            List<UML_Attribute> classAttributes = new List<UML_Attribute>();
            Dictionary<string, List<string>> attributes = new Dictionary<string, List<string>>();
            classAttributes = reader.getAttribute(attr);

            return classAttributes;
        }

        /// <summary>
        /// Main Method for handling parsed data about existing Methods
        /// </summary>
        /// <param name="methods"> Containing information about the methods </param>
        /// <returns> Datamodel valid List of all Methods for each Class or Interface </returns>
        public List<UML_Method> AnalyzeMethodLabel (string methods)
        {
            BaseReader readerInstance = new BaseReader(this.filepath);
            List<UML_Method> classMethods = new List<UML_Method>();
            classMethods = readerInstance.getMethod(methods);
            return classMethods;
        }

        // Interface Method to get datamodel for other components
        public CodeGenerator.Datamodel.Datamodel getDatamodel()
         {
            Datamodel.Datamodel datamodel = createDatamodel();
            return datamodel;
         }


    }
}
