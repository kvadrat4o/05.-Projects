﻿using BashSoft.IO.Commands;
using BashSoft.Exceptions;
using SimpleJudge;
using BashSoft.Contracts;
using BashSoft.Attributes;

namespace BashSoft
{
    [Alias("cdAbs")]
    public class ChangeAbsolutePathCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeAbsolutePathCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }
            string absPath = this.Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryAbsolute(absPath);
        }
    }
}