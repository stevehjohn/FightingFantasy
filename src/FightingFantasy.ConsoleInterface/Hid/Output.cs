using System;
using System.Text;
using System.Threading;
using FightingFantasy.ConsoleInterface.Infrastructure;

namespace FightingFantasy.ConsoleInterface.Hid
{
    public class Output : IOutput
    {
        public void Write(string text)
        {
            Console.CursorVisible = false;
            
            Console.ForegroundColor = AppSettings.Instance.ColourScheme.Normal;

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == '<')
                {
                    if (text[i + 1] == '/')
                    {
                        while (text[i] != '>')
                        {
                            i++;
                        }

                        Console.ForegroundColor = AppSettings.Instance.ColourScheme.Normal;

                        continue;
                    }

                    i++;

                    var emphasis = new StringBuilder();

                    while (text[i] != '>')
                    {
                        emphasis.Append(text[i]);

                        i++;
                    }

                    ConsoleColor colour;

                    switch (emphasis.ToString().ToLower())
                    {
                        case "b":
                            colour = AppSettings.Instance.ColourScheme.Bold;
                            break;
                        case "i":
                            colour = AppSettings.Instance.ColourScheme.Italic;
                            break;
                        case "u":
                            colour = AppSettings.Instance.ColourScheme.Underline;
                            break;
                        case "c":
                            colour = AppSettings.Instance.ColourScheme.Caps;
                            break;
                        default:
                            colour = AppSettings.Instance.ColourScheme.Normal;
                            break;
                    }

                    Console.ForegroundColor = colour;

                    continue;
                }

                Console.Write(text[i]);

                Thread.Sleep(text[i] == '\n' 
                                 ? AppSettings.Instance.LineBreakDelay 
                                 : AppSettings.Instance.TextDelay);
            }
        }
    }
}