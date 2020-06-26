using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class DatamodelMissingContentException : Exception
    {
        public string Text { get; set; }

        public DatamodelMissingContentException(string message)
        {
            Text = message;
        }

        public override string Message => Text;
    }
}
