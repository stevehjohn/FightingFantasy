using System;
using System.Diagnostics.CodeAnalysis;

namespace FightingFantasy.ConsoleInterface.Hid
{
    [ExcludeFromCodeCoverage]
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

        public void Write(string text)
        {
            System.Console.Write(text);
        }

        public void Clear()
        {
            System.Console.Clear();
        }

        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}