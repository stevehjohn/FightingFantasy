using System.Collections.Generic;

namespace FightingFantasy.Engine.Models
{
    public class GameState
    {
        public Dictionary<int, Location> Map { get; private set; }

        public void LoadMap(string path)
        {
        }
    }
}