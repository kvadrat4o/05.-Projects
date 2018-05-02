using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Exceptions
{
    class InvalidCommandException : Exception
    {
        private const string InvalidCommandMessage = "The command '{0}' is invalid";

        public InvalidCommandException() : base(InvalidCommandMessage)
        {

        }

        public InvalidCommandException(string command) : base(string.Format(InvalidCommandMessage, command)) { }
    }
}
