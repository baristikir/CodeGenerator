using System;

namespace Exceptions
{
    public class InvalidMethodParameterException : Exception
    {
        public string Text { get; set; }

        public InvalidMethodParameterException(string message)
        {
            Text = message;
        }

        public override string Message => Text;
    }
}
