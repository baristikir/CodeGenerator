using System;

namespace Exceptions
{
    public class DatamodelMissingInformationException : Exception
    {
        public string Text { get; set; }

        public DatamodelMissingInformationException(string message)
        {
            Text = message;
        }

        public override string Message => Text;
    }

}
