﻿using FightingFantasy.Engine.Core;

namespace FightingFantasy.Engine.Models
{
    public class Protagonist
    {
        public ProtagonistAttribute Skill { get; }
        public ProtagonistAttribute Stamina { get; }
        public ProtagonistAttribute Luck { get; }

        public Protagonist(IDie die)
        {
            Skill = new ProtagonistAttribute();
            Stamina = new ProtagonistAttribute();
            Luck = new ProtagonistAttribute();

            Skill.Value = 6 + die.Roll();
            Stamina.Value = 12 + die.Roll() + die.Roll();
            Luck.Value = 6 + die.Roll();
        }
    }
}
