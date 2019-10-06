using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FightingFantasy.Engine.Models
{
    public class GameState
    {
        public string Title { get; set; }

        public Dictionary<int, Location> Map { get; set; }

        public Protagonist Protagonist { get; set; }

        public bool IsSavedGame = false;

        public static GameState LoadGame(string path)
        {
            var json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<GameState>(json);
        }
    }
}