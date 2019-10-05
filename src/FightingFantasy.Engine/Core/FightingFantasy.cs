using FightingFantasy.Engine.Models;

namespace FightingFantasy.Engine.Core
{
    public class FightingFantasy
    {
        private readonly GameState _gameState;

        public FightingFantasy(GameState gameState)
        {
            _gameState = gameState;
        }
    }
}