using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonInterfaces;
using CodeGenerator.Reader;
using CodeGenerator.Datamodel;
using CodeGenerator.Generator;
using System.IO;
using System.Security.AccessControl;
using Exceptions;

namespace CodeGenerator.Controller
{
    public class Controller : IController
    {
        #region Interfacemethod
        /// <summary>
        /// Interface-Methode StartProcess(). Wenn Berechtigung auf Graphml-Datei erlaubt ist, 
        /// ruft sie ExchangeData() auf. Fängt Exceptions auf und gibt ihre Messages der GUI zurück.
        /// </summary>
        /// <param name="filePath_Model">Graphml-Dateipfad als string vom GUI</param>
        /// <param name="filePath_Output">Ausgabepfad als string vom GUI</param>
        /// <returns>string, wenn eine Exception abgefangen wird oder null, wenn nicht </returns>
        public string StartProcess(string filePath_Model, string filePath_Output, out Datamodel.Datamodel dtm)
        {
            if (CheckPermission(filePath_Output))
            {
                try
                {
                    dtm = ExchangeData(filePath_Model, filePath_Output);

                    return null;
                }
                catch(DatamodelMissingContentException e)
                {
                    dtm = null;
                    return e.Message;
                }
                catch(DatamodelMissingInformationException e)
                {
                    dtm = null;
                    return e.Message;
                }
                catch(InvalidUMLShapesException e)
                {
                    dtm = null;
                    return e.Message;
                }
                catch(InvalidMethodParameterException e)
                {
                    dtm = null;
                    return e.Message;
                }
                // Wenn eine andere, für den Nutzer unwichtige, Exception ausgelöst wird, wird der Text zurückgegeben.
                catch (Exception)
                {
                    dtm = null;
                    return "Wir bitten um Entschuldigung, da ist etwas im System falsch gelaufen. Bitte wenden Sie sich an den Hersteller!";
                }
            }
            // Wenn CheckPermission false zurückgibt, wird der entsprechende Text zurückgegeben.
            else
            {
                dtm = null;
                return "Dateien konnten im ausgewählten Verzeichnis nicht erstellt werden. Schreibberechtigung verweigert! Bitte überprüfen Sie die Eigenschaften des Verzeichnisses oder ändern Sie den Ausgabeort!";
            }
        }

        #endregion

        #region ExchangeData
        /// <summary>
        /// Erstellt Reader und Generator und führt deren Interface-Methoden aus.
        /// </summary>
        /// <param name="filePath_Model">Gibt dem Reader den Dateipfad mit.</param>
        /// <param name="filePath_Output">Gibt dem Generator den Ausgabepfad mit.</param>
        public Datamodel.Datamodel ExchangeData(string filePath_Model, string filePath_Output)
        {
            Reader.Reader reader = new Reader.Reader(filePath_Model);
            Datamodel.Datamodel datamodel = reader.getDatamodel();
            Generator.Generator generator = new Generator.Generator(filePath_Output, datamodel);
            if (generator.generateCode())
            {
                return datamodel;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region CheckPermission
        /// <summary>
        /// GetAcessControl() versucht eine Liste von Berechtigungen vom Ausgabeort abzurufen.
        /// Eine UnauthorizedAccessException wird abgefangen, wenn der Ausgabeort ReadOnly ist 
        /// oder keine Zugriffsberechtigungen vorliegen.
        /// </summary>
        /// <param name="filePath">der Ausgabeort</param>
        /// <returns>true, wenn Berechtigung vorliegt. false, wenn nicht</returns>
        public bool CheckPermission(string filePath)
        {
            try
            {
                DirectorySecurity ds = Directory.GetAccessControl(filePath);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }
        #endregion
    }
}