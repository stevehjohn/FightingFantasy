using System.Collections.Generic;

namespace FightingFantasy.Engine.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public List<Choice> Choices { get; set; }

        public int VisitCount { get; set; }
    }
}