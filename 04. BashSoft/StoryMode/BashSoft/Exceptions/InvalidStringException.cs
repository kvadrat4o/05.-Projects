using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Exceptions
{
    class InvalidStringException  :Exception
    {
        private const string InvalidName = "The value of the variable cannot be null or empty!";

        public InvalidStringException():base(InvalidName)
        {

        }

        public InvalidStringException(string message) : base(message)
        {

        }
    }
}
