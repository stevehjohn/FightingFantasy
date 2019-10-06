using FightingFantasy.Engine.Core;

namespace FightingFantasy.Engine.Models
{
    public class Protagonist
    {
        public ProtagonistAttribute Skill { get; set; }

        public ProtagonistAttribute Stamina { get; set; }

        public ProtagonistAttribute Luck { get; set; }

        public Protagonist()
        {
        }

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
