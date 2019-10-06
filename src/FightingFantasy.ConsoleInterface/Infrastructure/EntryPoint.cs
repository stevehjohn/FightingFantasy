using System.Diagnostics.CodeAnalysis;
using FightingFantasy.ConsoleInterface.Hid;

namespace FightingFantasy.ConsoleInterface.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class EntryPoint
    {
        public static void Main()
        {
            var console = new Console();

            var ui = new ConsoleUi(new Output(console, new Sleeper()), new Input(console));

            ui.Run();
        }
    }
}
