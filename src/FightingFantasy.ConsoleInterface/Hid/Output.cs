using System;
using System.Text;
using FightingFantasy.ConsoleInterface.Infrastructure;

namespace FightingFantasy.ConsoleInterface.Hid
{
    public class Output : IOutput
    {
        private readonly IConsole _console;
        private readonly ISleeper _sleeper;

        public Output(IConsole console, ISleeper sleeper)
        {
            _console = console;
            _sleeper = sleeper;
        }

        public void Write(string text)
        {
            _console.CursorVisible = false;
            
            _console.ForegroundColour = AppSettings.Instance.ColourScheme.Normal;

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

                        _console.ForegroundColour = AppSettings.Instance.ColourScheme.Normal;

                        continue;
                    }

                    i++;

                    var markup = new StringBuilder();

                    while (text[i] != '>')
                    {
                        markup.Append(text[i]);

                        i++;
                    }

                    ConsoleColor colour;

                    switch (markup.ToString().ToLower())
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
                        case "br":
                            _console.Write("\n\n");
                            break;
                        default:
                            colour = AppSettings.Instance.ColourScheme.Normal;
                            break;
                    }

                    _console.ForegroundColour = colour;

                    continue;
                }

                _console.Write(text[i]);

                if (! _console.KeyAvailable)
                {
                    _sleeper.Sleep(text[i] == '\n'
                                       ? AppSettings.Instance.LineBreakDelay
                                       : AppSettings.Instance.TextDelay);
                }
            }
        }

        public void Clear()
        {
            _console.Clear();
        }
    }
}