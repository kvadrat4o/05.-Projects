using BashSoft;
using BashSoft.Contracts;
using System;

class InputReader : IReader
{
    private const string endCommand = "quit";
    private IInterpreter interpreter;

    public InputReader(IInterpreter interpreter)
    {
        this.interpreter = interpreter;
    }

    public void StartReadingCommands()
    {
        OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
        string input = Console.ReadLine();
        input = input.Trim();

        while (input != endCommand)
        {
            this.interpreter.InterpredCommand(input);
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            input = Console.ReadLine();
            input = input.Trim();
        }
    }
}

