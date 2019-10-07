using FightingFantasy.Engine.Core;
using NUnit.Framework;

namespace FightingFantasy.Engine.Tests.Core
{
    [TestFixture]
    public class FightingFantasyFactoryTests
    {
        [Test]
        public void Factory_return_initialised_FightingFantasy_class()
        {
            Engine.Core.FightingFantasy fightingFantasy = null;

            Assert.DoesNotThrow(() => fightingFantasy = FightingFantasyFactory.Create());

            Assert.That(fightingFantasy, Is.Not.Null);
        }
    }
}