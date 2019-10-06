using FightingFantasy.ConsoleInterface.Infrastructure;

namespace FightingFantasy.ConsoleInterface.Hid
{
    public class Input : IInput
    {
        private readonly IConsole _console;

        public Input(IConsole console)
        {
            _console = console;
        }

        public string ReadLine()
        {
            _console.CursorVisible = true;

            _console.ForegroundColour = AppSettings.Instance.ColourScheme.Prompt;

            _console.Write("> ");

            _console.ForegroundColour = AppSettings.Instance.ColourScheme.UserInput;

            return _console.ReadLine();
        }
    }
}