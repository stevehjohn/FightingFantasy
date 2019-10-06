using System;

namespace FightingFantasy.ConsoleInterface.Hid
{
    public interface IConsole
    {
        ConsoleColor ForegroundColour { set; }

        bool CursorVisible { set; }

        bool KeyAvailable { get; }

        int CursorLeft { get; }

        int WindowWidth { get; }

        void Write(char character);

        void Write(string text);

        void Clear();

        string ReadLine();
    }
}