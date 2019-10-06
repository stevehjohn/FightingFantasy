namespace FightingFantasy.Engine.Models
{
    public class Protagonist
    {
        public ProtagonistAttribute Skill { get; set; }

        public ProtagonistAttribute Stamina { get; set; }

        public ProtagonistAttribute Luck { get; set; }

        public Protagonist()
        {
            Skill = new ProtagonistAttribute();
            Stamina = new ProtagonistAttribute();
            Luck = new ProtagonistAttribute();
        }
    }
}
