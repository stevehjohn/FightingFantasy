using System;

namespace FightingFantasy.ConsoleInterface.Hid
{
    public interface IConsole
    {
        ConsoleColor ForegroundColour { set; }

        bool CursorVisible { set; }

        void Write(char character);

        void Write(string text);

        void Clear();

        string ReadLine();
    }
}