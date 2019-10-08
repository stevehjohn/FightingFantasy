using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace FightingFantasy.Engine.Models
{
    public class GameState
    {
        public List<int> LocationHistory;

        public string Title { get; set; }

        public Dictionary<int, Location> Map { get; set; }

        public Protagonist Protagonist { get; set; }

        public bool IsSavedGame { get; set; }

        public Dictionary<string, string> Resources { get; set; }

        public int Location
        {
            get => LocationHistory.LastOrDefault();
            set => LocationHistory.Add(value);
        }

        public GameState()
        {
            LocationHistory = new List<int>();
        }

        public static GameState LoadGame(string path)
        {
            var json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<GameState>(json);
        }
    }
}