using System;

namespace FightingFantasy.ConsoleInterface.Hid
{
    public class Input : IInput
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}