using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.Datamodel;

namespace CommonInterfaces
{
    public interface IController
    {
        string StartProcess(string filePath_Model, string filePath_Output, out Datamodel dtm);
    }
}