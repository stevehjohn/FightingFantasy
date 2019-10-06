using FightingFantasy.Engine.Models;

namespace FightingFantasy.Engine.Core
{
    public class FightingFantasy
    {
        private GameState _gameState;

        public void LoadGame(string path)
        {
            _gameState = GameState.LoadGame(path);
        }
    }
}