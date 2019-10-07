using System.IO;
using System.Linq;
using FightingFantasy.Engine.Core;
using FightingFantasy.Engine.Models;
using Newtonsoft.Json;

namespace FightingFantasy.ConsoleInterface.Hid
{
    public class ConsoleUi
    {
        private readonly IOutput _output;
        private readonly IInput _input;
        private readonly Engine.Core.FightingFantasy _engine;

        private State _state;
        private bool _locationChanged;

        public ConsoleUi(IOutput output, IInput input)
        {
            _output = output;
            _input = input;

            _state = State.Started;

            _engine = FightingFantasyFactory.Create();
        }

        public void Run()
        {
            _output.Clear();

            _output.Write("\nWelcome to Stevö John's <b>Fighting Fantasy</b> Game Engine!\n\n");
            _output.Write("Type <b>help</b> at any time for a list of commands.\n\n");

            while (true)
            {
                if (_locationChanged)
                {
                    _output.Write("\n");

                    _output.Write(_engine.GetLocationDescription());

                    _output.Write("\n\n");

                    foreach (var engineEvent in _engine.Events)
                    {
                        _output.Write(engineEvent);

                        _output.Write("\n");
                    }

                    if (_engine.Events.Any())
                    {
                        _output.Write("\n\n");
                    }

                    var i = 1;

                    foreach (var choice in _engine.GetChoices())
                    {
                        _output.Write($"  <b>{i}</b> - {choice.Description}\n");

                        i++;
                    }
                    
                    _output.Write("\n");

                    _locationChanged = false;
                }

                var input = _input.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    _output.Write("\nPlease enter an instruction.\n\n");
                    continue;
                }

                if (int.TryParse(input, out var index))
                {
                    switch (_state)
                    {
                        case State.SelectingGame:
                            StartGame(index);
                            continue;
                        case State.Playing:
                            _engine.MakeChoice(index - 1);
                            _locationChanged = true;
                            continue;
                    }
                }

                switch (input)
                {
                    case "new":
                    case "start":
                        ListGames();
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

            // TODO: Inventory, Health, Describe, Options

            _output.Write("\n");
        }

        private void ListGames()
        {
            _output.Write("\nPlease enter the number of the game you'd like to start:\n\n");

            var files = Directory.EnumerateFiles(".\\Games").OrderBy(s => s).ToList();

            var count = 0;

            foreach (var file in files)
            {
                count++;

                var json = File.ReadAllText(file);

                var state = JsonConvert.DeserializeObject<GameState>(json);

                _output.Write($"  <b>{count}</b> - <u>{state.Title}</u>.\n");
            }

            _output.Write("\n");

            _state = State.SelectingGame;
        }

        private void StartGame(int index)
        {
            var files = Directory.EnumerateFiles(".\\Games").OrderBy(s => s).ToList();

            if (index < 1 || index > files.Count)
            {
                _output.Write("\nNot a valid game id. Type <b>New</b> again to see a list of games available.\n\n");

                return;
            }

            _output.Clear();

            _engine.LoadGame(files[index - 1]);

            _output.Write($"<u>{_engine.Title}</u>\n");

            _output.Write($"<u>{new string('-', _engine.Title.Length)}</u>\n");

            _locationChanged = true;

            _state = State.Playing;
        }
    }
}