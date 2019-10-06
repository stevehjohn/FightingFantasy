using System;

namespace FightingFantasy.ConsoleInterface.Hid
{
    public class Console : IConsole
    {
        public ConsoleColor ForegroundColour
        {
            set => System.Console.ForegroundColor = value;
        }

        public bool CursorVisible
        {
            set => System.Console.CursorVisible = value;
        }

        public void Write(char character)
        {
            System.Console.Write(character);
        }

        public void Clear()
        {
            System.Console.Clear();
        }
    }
}