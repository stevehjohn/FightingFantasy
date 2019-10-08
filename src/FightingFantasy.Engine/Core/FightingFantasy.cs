﻿using System;
using System.Collections.Generic;
using System.Linq;
using FightingFantasy.Engine.Extensions;
using FightingFantasy.Engine.Models;

namespace FightingFantasy.Engine.Core
{
    public class FightingFantasy
    {
        private readonly IDie _die;

        internal GameState GameState;

        public string Title => GameState.Title;

        public List<string> Events { get; }

        public int Luck => GameState.Protagonist.Luck.Value;

        public int Skill => GameState.Protagonist.Skill.Value;

        public int Stamina => GameState.Protagonist.Stamina.Value;

        public int LocationsVisited => GameState.LocationHistory.Distinct().Count();
        
        public int LocationsVisitedPercent => (int) Math.Ceiling(GameState.LocationHistory.Distinct().Count() / (float) GameState.Map.Count * 100.0f);

        public FightingFantasy(IDie die)
        {
            _die = die;

            Events = new List<string>();
        }

        public void LoadGame(string path)
        {
            GameState = GameState.LoadGame(path);

            if (! GameState.IsSavedGame)
            {
                GameState.Protagonist = new Protagonist
                                         {
                                             Skill =
                                             {
                                                 Value = 6 + _die.Roll()
                                             },
                                             Stamina =
                                             {
                                                 Value = 12 + _die.Roll() + _die.Roll()
                                             },
                                             Luck =
                                             {
                                                 Value = 6 + _die.Roll()
                                             }
                                         };

                GameState.Location = 0;
            }
        }

        public string GetLocationDescription()
        {
            return GameState.Map[GameState.Location].Description;
        }

        public IEnumerable<Choice> GetChoices()
        {
            var choices = (GameState.Map[GameState.Location].Choices ?? Enumerable.Empty<Choice>()).ToList();

            var defaultChoice = choices.FirstOrDefault(c => c.DefaultIfItemIdPossessed > 0);

            if (defaultChoice != null)
            {
                if (GameState.Protagonist.Inventory.Any(i => i.Id == defaultChoice.DefaultIfItemIdPossessed))
                {
                    return choices.Where(c => c.DefaultIfItemIdPossessed > 0);
                }

                return choices.Where(c => c.DefaultIfItemIdPossessed == 0);
            }

            return choices.Where(c => c.RequiredItemId == 0 || GameState.Protagonist.Inventory.Any(i => i.Id == c.RequiredItemId));
        }

        public void MakeChoice(int index)
        {
            GameState.Location = GetChoices().ToList()[index].Id;

            ProcessLocationEvents();
        }

        private void ProcessLocationEvents()
        {
            Events.Clear();

            var location = GameState.Map[GameState.Location];

            if (location.StaminaChange != 0)
            {
                var delta = ProcessAttributeChange(GameState.Protagonist.Stamina, location.StaminaChange);

                if (delta != 0)
                {
                    Events.Add(GameState.Resources[delta > 0 ? "stamina-up" : "stamina-down"].Replace("{0}", Math.Abs(delta).ToString()).Pluralise(delta));
                }
            }

            if (location.LuckChange != 0)
            {
                var delta = ProcessAttributeChange(GameState.Protagonist.Luck, location.LuckChange);

                if (delta != 0)
                {
                    Events.Add(GameState.Resources[delta > 0 ? "luck-up" : "luck-down"].Replace("{0}", Math.Abs(delta).ToString()).Pluralise(delta));
                }
            }

            if (location.RestoreStamina)
            {
                GameState.Protagonist.Stamina.Value = GameState.Protagonist.Stamina.InitialValue;
            }

            if (location.RestoreLuck)
            {
                GameState.Protagonist.Luck.Value = GameState.Protagonist.Luck.InitialValue;
            }
        }

        private int ProcessAttributeChange(ProtagonistAttribute attribute, int delta)
        {
            var value = attribute.Value;

            attribute.Value += delta;

            if (attribute.Value > attribute.InitialValue)
            {
                attribute.Value = attribute.InitialValue;
            }

            var actualDelta = attribute.Value - value;

            return actualDelta;
        }
    }
}