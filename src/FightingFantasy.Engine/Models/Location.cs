using System.Collections.Generic;

namespace FightingFantasy.Engine.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public List<Choice> Choices { get; set; }

        public int VisitCount { get; set; }

        public int LuckChange { get; set; }

        public int StaminaChange { get; set; }

        public EventCondition StaminaChangeEventCondition { get; set; }

        public bool RestoreStamina { get; set; }

        public bool RestoreLuck { get; set; }

        public List<int> Items { get; set; }

        public LuckTest LuckTest { get; set; }

        public int Success { get; set; }

        public bool CanEscape { get; set; }

        public int EscapeLocation { get; set; }

        public bool IsEnd { get; set; }
    }
}