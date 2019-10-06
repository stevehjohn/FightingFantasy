using System.Diagnostics.CodeAnalysis;
using FightingFantasy.ConsoleInterface.Hid;

namespace FightingFantasy.ConsoleInterface.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class EntryPoint
    {
        public static void Main()
        {
            var ui = new ConsoleUi(new Output());

            ui.Run();
        }
    }
}
