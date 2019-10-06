using System.Threading;

namespace FightingFantasy.ConsoleInterface.Hid
{
    public class Sleeper : ISleeper
    {
        public void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}