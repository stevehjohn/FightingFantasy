using System;
using System.IO;
using Newtonsoft.Json;

namespace FightingFantasy.ConsoleInterface.Infrastructure
{
    public class AppSettings
    {
        private static readonly Lazy<AppSettings> Lazy = new Lazy<AppSettings>(GetAppSettings);

        public ColourScheme ColourScheme { get; set; }

        public int TextDelay { get; set; }

        public int LineBreakDelay { get; set; }

        public static AppSettings Instance => Lazy.Value;

        private static AppSettings GetAppSettings()
        {
            var json = File.ReadAllText("app-settings.json");

            return JsonConvert.DeserializeObject<AppSettings>(json);
        }
    }
}