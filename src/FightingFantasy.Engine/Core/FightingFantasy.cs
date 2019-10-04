using FightingFantasy.Engine.Models;

namespace FightingFantasy.Engine.Core
{
    public class FightingFantasy
    {
        private readonly Protagonist _protagonist;

        public FightingFantasy(Protagonist protagonist)
        {
            _protagonist = protagonist;
        }
    }
}