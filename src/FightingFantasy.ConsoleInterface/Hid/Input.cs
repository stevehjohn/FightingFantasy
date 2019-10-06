using System;

namespace FightingFantasy.ConsoleInterface.Hid
{
    public class Input : IInput
    {
        private readonly IConsole _console;

        public Input(IConsole console)
        {
            _console = console;
        }

        public string Read()
        {
            throw new NotImplementedException();
        }
    }
}