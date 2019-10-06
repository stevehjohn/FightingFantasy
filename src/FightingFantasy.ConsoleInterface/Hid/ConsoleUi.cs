using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using FightingFantasy.Engine.Models;
using Newtonsoft.Json;

namespace FightingFantasy.ConsoleInterface.Hid
{
    public class ConsoleUi
    {
        private readonly IOutput _output;
        private readonly IInput _input;

        public ConsoleUi(IOutput output, IInput input)
        {
            _output = output;
            _input = input;
        }

        public void Run()
        {
            _output.Clear();

            _output.Write("\nWelcome to Stevö John's <b>Fighting Fantasy</b> Game Engine!\n\n");
            _output.Write("Type <b>help</b> at any time for a list of commands.\n\n");

            while (true)
            {
                var input = _input.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    _output.Write("\nPlease enter an instruction.\n\n");
                    continue;
                }

                switch (input)
                {
                    case "new":
                    case "start":
                        StartGame();
                        break;
                    case "help":
                        ShowHelpText();
                        break;
                    case "exit":
                    case "quit":
                    case "bye":
                        _output.Write("\nThank you for playing, bye!\n\n");
                        return;
                    case "clear":
                    case "cls":
                        _output.Clear();
                        break;
                    default:
                        _output.Write($"\nI'm sorry, I don't know how to <b>{input}</b>.\n\n");
                        break;
                }
            }
        }

        private void ShowHelpText()
        {
            _output.Write("\nThe following commands can be used at any time:\n\n");

            _output.Write("  <b>Help</b>  - Displays this list of commands.\n");
            _output.Write("  <b>New</b>   - Start a new game.\n");
            _output.Write("  <b>Load</b>  - Load a saved game.\n");
            _output.Write("  <b>Save</b>  - Save the game so you can come back later.\n");
            _output.Write("  <b>Clear</b> - Clear the screen.\n");
            _output.Write("  <b>Exit</b>  - Quit the game.\n");

            _output.Write("\n");
        }

        private void StartGame()
        {
            _output.Write("\nPlease enter the number the game you'd like to start:\n\n");

            var files = Directory.EnumerateFiles(".\\Games").ToList();

            var count = 0;

            foreach (var file in files)
            {
                count++;

                var json = File.ReadAllText(file);

                var state = JsonConvert.DeserializeObject<GameState>(json);

                _output.Write($"  <b>{count}</b> - <u>{state.Title}</u>.\n");
            }

            _output.Write("\n");
        }
    }
}