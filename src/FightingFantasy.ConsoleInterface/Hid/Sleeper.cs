using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace FightingFantasy.ConsoleInterface.Hid
{
    [ExcludeFromCodeCoverage]
    public class Sleeper : ISleeper
    {
        public void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}