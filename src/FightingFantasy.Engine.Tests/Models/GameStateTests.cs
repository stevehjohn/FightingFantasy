using FightingFantasy.Engine.Models;
using NUnit.Framework;

namespace FightingFantasy.Engine.Tests.Models
{
    [TestFixture]
    public class GameStateTests
    {
        private GameState _gameState;

        [SetUp]
        public void SetUp()
        {
            _gameState = new GameState();
        }

        [Test]
        public void LoadMap_can_deserialise_map_JSON()
        {
            _gameState.LoadMap(".\\TestFiles\\Map.json");
        }
    }
}