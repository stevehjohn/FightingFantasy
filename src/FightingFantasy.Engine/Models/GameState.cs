using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FightingFantasy.Engine.Models
{
    public class GameState
    {
        public Dictionary<int, Location> Map { get; private set; }

        public void LoadMap(string path)
        {
            var json = File.ReadAllText(path);

            Map = JsonConvert.DeserializeObject<Dictionary<int, Location>>(json);
        }
    }
}