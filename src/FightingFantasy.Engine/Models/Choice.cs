namespace FightingFantasy.Engine.Models
{
    public class Choice
    {
        public string Description { get; set; }

        public int Id { get; set; }

        public int RequiredItemId { get; set; }

        public int DefaultIfItemIdPossessed { get; set; }
    }
}