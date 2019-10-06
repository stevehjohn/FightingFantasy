using System.Collections.Generic;

namespace FightingFantasy.Engine.Models
{
    public class ProtagonistAttribute
    {
        public List<int> History { get; set; }

        public int HistoryLength => History.Count;

        public int InitialValue => History[0];

        public int Value
        {
            get => History[History.Count - 1];
            set => History.Add(value);
        }

        public ProtagonistAttribute()
        {
            History = new List<int>();
        }
    }
}