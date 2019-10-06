using FightingFantasy.Engine.Models;

namespace FightingFantasy.Engine.Core
{
    public class FightingFantasy
    {
        private readonly IDie _die;

        private GameState _gameState;

        public FightingFantasy(IDie die)
        {
            _die = die;
        }

        public void LoadGame(string path)
        {
            _gameState = GameState.LoadGame(path);

            if (! _gameState.IsSavedGame)
            {
                _gameState.Protagonist = new Protagonist
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