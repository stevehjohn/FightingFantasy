using System;
using System.Text;
using System.Threading;

namespace FightingFantasy.ConsoleInterface.Hid
{
    public class Output : IOutput
    {
        public void Write(string text)
        {
            Console.CursorVisible = false;

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == '#')
                {
                    i++;

                    var colour = new StringBuilder();

                    while (text[i] != ';')
                    {
                        colour.Append(text[i]);

                        i++;
                    }
                    
                    Console.ForegroundColor = Enum.Parse<ConsoleColor>(colour.ToString());

                    continue;
                }

                Console.Write(text[i]);

                Thread.Sleep(20);
            }
        }
    }
}