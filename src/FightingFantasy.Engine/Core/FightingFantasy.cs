using FightingFantasy.Engine.Models;

namespace FightingFantasy.Engine.Core
{
    public class FightingFantasy
    {
        private readonly IDie _die;

        internal GameState GameState;

        public string Title => GameState.Title;

        public FightingFantasy(IDie die)
        {
            _die = die;
        }

        public void LoadGame(string path)
        {
            GameState = GameState.LoadGame(path);

            if (! GameState.IsSavedGame)
            {
                GameState.Protagonist = new Protagonist
                                         {
                                             Skill =
                                             {
                                                 Value = 6 + _die.Roll()
                                             },
                                             Stamina =
                                             {
                                                 Value = 12 + _die.Roll() + _die.Roll()
                                             },
                                             Luck =
                                             {
                                                 Value = 6 + _die.Roll()
                                             }
                                         };
            }
        }
    }
}