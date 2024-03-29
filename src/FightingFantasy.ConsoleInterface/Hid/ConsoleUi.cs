﻿using System.IO;
using System.Linq;
using System.Reflection;
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
        private bool _showOptions;
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
                        _output.Write("\n");
                    }

                    var items = _engine.GetLocationItems().ToList();

                    if (items.Any())
                    {
                        _output.Write("Items in the area:\n\n");

                        foreach (var item in items)
                        {
                            _output.Write($"  <u>{item.Description}</u>\n");
                        }

                        _output.Write("\n");
                    }

                    if (_engine.LocationsVisited == 1)
                    {
                        _output.Write("Dice have been rolled and your initial stats have been determined as...\n");

                        _output.Write($"\n<i>Skill</i>: {_engine.Skill}, <i>Stamina</i>: {_engine.Stamina}, <i>Luck</i> {_engine.Luck}\n\n");
                    }
                }

                if (_locationChanged || _showOptions)
                {
                    var i = 1;

                    foreach (var choice in _engine.GetChoices())
                    {
                        _output.Write($"  <b>{i}</b> - {choice.Description}\n");

                        i++;
                    }
                    
                    var items = _engine.GetLocationItems().ToList();

                    foreach (var item in items)
                    {
                        _output.Write($"  <b>{i}</b> - Take the {item.Description}.\n");

                        i++;
                    }

                    _output.Write("\n");

                    _locationChanged = false;
                    _showOptions = false;
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
                            index--;

                            var choices = _engine.GetChoices().ToList();

                            if (index < choices.Count)
                            {
                                _engine.MakeChoice(index);

                                _locationChanged = true;
                            }
                            else
                            {
                                index -= choices.Count;

                                var items = _engine.GetLocationItems().ToList();

                                if (index < items.Count)
                                {
                                    var item = _engine.GetLocationItems().ToList()[index];

                                    _engine.TakeItem(item.Id);

                                    _output.Write($"\nYou take the <u>{item.Description}</u>.\n\n");

                                    _showOptions = true;
                                }
                            }

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
                    case "stats":
                        _output.Write($"\n<i>Skill</i>: {_engine.Skill}, <i>Stamina</i>: {_engine.Stamina}, <i>Luck</i> {_engine.Luck}\n\n");
                        _output.Write($"<i>Locations visited</i>: {_engine.LocationsVisited} ({_engine.LocationsVisitedPercent}%)\n\n");
                        break;
                    case "desc":
                        _locationChanged = true;
                        break;
                    case "items":
                        var items = _engine.GetInventory().ToList();
                        if (items.Count == 0)
                        {
                            _output.Write("\nYou are not carrying anything.\n\n");
                        }
                        else
                        {
                            _output.Write("\nYou are carrying:\n\n");

                            foreach (var item in items)
                            {
                                _output.Write($"  <u>{item.Description}</u>\n");
                            }

                            _output.Write("\n");
                        }

                        break;
                    default:
                        // ncrunch: no coverage start
                        if (input.StartsWith("tp"))
                        {
                            var gameStatePropertyInfo = _engine.GetType().GetField("GameState", BindingFlags.Instance | BindingFlags.NonPublic);
                            var gameStateProperty = (GameState)gameStatePropertyInfo?.GetValue(_engine);
                            if (gameStateProperty != null)
                            {
                                gameStateProperty.Location = int.Parse(input.Substring(3));
                                _locationChanged = true;

                                var processEventsMethodInfo = _engine.GetType().GetMethod("ProcessLocationEvents", BindingFlags.Instance | BindingFlags.NonPublic);
                                processEventsMethodInfo?.Invoke(_engine, null);

                                var processLuckOutcomeMethodInfo = _engine.GetType().GetMethod("ProcessLocationLuckOutcome", BindingFlags.Instance | BindingFlags.NonPublic);
                                processLuckOutcomeMethodInfo?.Invoke(_engine, null);
                            }
                            break;
                        }
                        else if (input.StartsWith("lset"))
                        {
                            var gameStatePropertyInfo = _engine.GetType().GetField("GameState", BindingFlags.Instance | BindingFlags.NonPublic);
                            var gameStateProperty = (GameState)gameStatePropertyInfo?.GetValue(_engine);
                            if (gameStateProperty != null)
                            {
                                gameStateProperty.Protagonist.Luck.Value = int.Parse(input.Substring(5));
                            }
                            break;
                        }
                        else if (input.StartsWith("kset"))
                        {
                            var gameStatePropertyInfo = _engine.GetType().GetField("GameState", BindingFlags.Instance | BindingFlags.NonPublic);
                            var gameStateProperty = (GameState)gameStatePropertyInfo?.GetValue(_engine);
                            if (gameStateProperty != null)
                            {
                                gameStateProperty.Protagonist.Skill.Value = int.Parse(input.Substring(5));
                            }
                            break;
                        }
                        else if (input.StartsWith("tset"))
                        {
                            var gameStatePropertyInfo = _engine.GetType().GetField("GameState", BindingFlags.Instance | BindingFlags.NonPublic);
                            var gameStateProperty = (GameState)gameStatePropertyInfo?.GetValue(_engine);
                            if (gameStateProperty != null)
                            {
                                gameStateProperty.Protagonist.Stamina.Value = int.Parse(input.Substring(5));
                            }
                            break;
                        }
                        else if (input.StartsWith("ti"))
                        {
                            var gameStatePropertyInfo = _engine.GetType().GetField("GameState", BindingFlags.Instance | BindingFlags.NonPublic);
                            var gameStateProperty = (GameState)gameStatePropertyInfo?.GetValue(_engine);
                            if (gameStateProperty != null)
                            {
                                gameStateProperty.Protagonist.Inventory.Add(int.Parse(input.Substring(3)));
                            }
                            break;
                        }
                        // ncrunch: no coverage end

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
            _output.Write("  <b>Stats</b> - Display your statistics.\n");
            _output.Write("  <b>Items</b> - Display the items in your inventory.\n");
            _output.Write("  <b>Desc</b>  - Describe your current location.\n");
            _output.Write("  <b>Save</b>  - Save the game so you can come back later.\n");
            _output.Write("  <b>Clear</b> - Clear the screen.\n");
            _output.Write("  <b>Exit</b>  - Quit the game.\n");

            // TODO: Inventory, Health, Describe, Options

            _output.Write("\n");
        }

        private void ListGames()
        {
            _output.Write("\nPlease enter the number of the game you'd like to start:\n\n");

            var files = Directory.EnumerateFiles("Games").OrderBy(s => s).ToList();

            var count = 0;

            foreach (var file in files)
            {
                count++;

                var json = File.ReadAllText(file);

                var state = JsonConvert.DeserializeObject<GameState>(json);

                _output.Write($"  <b>{count}</b> - <i>{state.Title}</i>.\n");
            }

            _output.Write("\n");

            _state = State.SelectingGame;
        }

        private void StartGame(int index)
        {
            var files = Directory.EnumerateFiles("Games").OrderBy(s => s).ToList();

            if (index < 1 || index > files.Count)
            {
                _output.Write("\nNot a valid game id. Type <b>New</b> again to see a list of games available.\n\n");

                return;
            }

            _output.Clear();

            _engine.LoadGame(files[index - 1]);

            _output.Write($"<i>{_engine.Title}</i>\n");

            _output.Write($"<i>{new string('-', _engine.Title.Length)}</i>\n");

            _locationChanged = true;

            _state = State.Playing;
        }
    }
}