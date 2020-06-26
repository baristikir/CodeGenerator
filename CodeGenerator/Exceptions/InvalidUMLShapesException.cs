using System;

namespace Exceptions
{
    public class InvalidUMLShapesException : Exception
    {
        public string Text { get; set; }

        public InvalidUMLShapesException(string message)
        {
            Text = message;
        }

        public override string Message => Text; 
    }
}
