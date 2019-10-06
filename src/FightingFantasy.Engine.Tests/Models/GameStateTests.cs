using FightingFantasy.Engine.Models;
using NUnit.Framework;

namespace FightingFantasy.Engine.Tests.Models
{
    [TestFixture]
    public class GameStateTests
    {
        [Test]
        public void LoadGame_can_deserialise_GameState_JSON()
        {
            var gameState = GameState.LoadGame(".\\TestFiles\\GameState.json");

            Assert.That(gameState.Title, Is.EqualTo("Demons of the Deep"));
            Assert.That(gameState.Protagonist, Is.Null);
            Assert.That(gameState.IsSavedGame, Is.False);

            Assert.That(gameState.Map.Count, Is.EqualTo(2));

            var location = gameState.Map[3];

            Assert.That(location.Id, Is.EqualTo(3));
            Assert.True(location.Description.StartsWith("You swim strongly"));
            Assert.True(location.Description.EndsWith("of the sand."));
            Assert.That(location.VisitCount, Is.EqualTo(0));
            Assert.That(location.Choices.Count, Is.EqualTo(1));
            Assert.That(location.Choices[0].Description, Is.EqualTo("Continue..."));
            Assert.That(location.Choices[0].Id, Is.EqualTo(196));

            location = gameState.Map[196];

            Assert.That(location.Id, Is.EqualTo(196));
            Assert.True(location.Description.StartsWith("You swim closer"));
            Assert.True(location.Description.EndsWith("will you do?"));
            Assert.That(location.VisitCount, Is.EqualTo(0));
            Assert.That(location.Choices.Count, Is.EqualTo(3));
            Assert.That(location.Choices[0].Description, Is.EqualTo("Run away."));
            Assert.That(location.Choices[0].Id, Is.EqualTo(10));
            Assert.That(location.Choices[1].Description, Is.EqualTo("Listen to the voice."));
            Assert.That(location.Choices[1].Id, Is.EqualTo(321));
            Assert.That(location.Choices[2].Description, Is.EqualTo("Attack."));
            Assert.That(location.Choices[2].Id, Is.EqualTo(26));
        }
        [Test]

        public void LoadGame_can_deserialise_SavedGameState_JSON()
        {
            var gameState = GameState.LoadGame(".\\TestFiles\\SavedGame.json");

            Assert.That(gameState.Title, Is.EqualTo("Demons of the Deep"));
            Assert.That(gameState.Protagonist, Is.Not.Null);
            Assert.That(gameState.IsSavedGame, Is.True);

            Assert.That(gameState.Map.Count, Is.EqualTo(2));

            var location = gameState.Map[3];

            Assert.That(location.Id, Is.EqualTo(3));
            Assert.True(location.Description.StartsWith("You swim strongly"));
            Assert.True(location.Description.EndsWith("of the sand."));
            Assert.That(location.VisitCount, Is.EqualTo(0));
            Assert.That(location.Choices.Count, Is.EqualTo(1));
            Assert.That(location.Choices[0].Description, Is.EqualTo("Continue..."));
            Assert.That(location.Choices[0].Id, Is.EqualTo(196));

            location = gameState.Map[196];

            Assert.That(location.Id, Is.EqualTo(196));
            Assert.True(location.Description.StartsWith("You swim closer"));
            Assert.True(location.Description.EndsWith("will you do?"));
            Assert.That(location.VisitCount, Is.EqualTo(0));
            Assert.That(location.Choices.Count, Is.EqualTo(3));
            Assert.That(location.Choices[0].Description, Is.EqualTo("Run away."));
            Assert.That(location.Choices[0].Id, Is.EqualTo(10));
            Assert.That(location.Choices[1].Description, Is.EqualTo("Listen to the voice."));
            Assert.That(location.Choices[1].Id, Is.EqualTo(321));
            Assert.That(location.Choices[2].Description, Is.EqualTo("Attack."));
            Assert.That(location.Choices[2].Id, Is.EqualTo(26));
        }
    }
}