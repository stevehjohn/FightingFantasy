namespace FightingFantasy.Engine.Models
{
    public class Protagonist
    {
        public ProtagonistAttribute Skill { get; }
        public ProtagonistAttribute Stamina { get; }
        public ProtagonistAttribute Luck { get; }

        public Protagonist()
        {
            Skill = new ProtagonistAttribute();
            Stamina = new ProtagonistAttribute();
            Luck = new ProtagonistAttribute();
        }
    }
}
