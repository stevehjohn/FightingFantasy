using System.Collections.Generic;

namespace FightingFantasy.Engine.Models
{
    public class ProtagonistAttribute
    {
        private readonly List<int> _history;

        public int HistoryLength => _history.Count;

        public int InitialValue => _history[0];

        public int Value
        {
            get => _history[_history.Count - 1];
            set => _history.Add(value);
        }

        public ProtagonistAttribute()
        {
            _history = new List<int>();
        }
    }
}