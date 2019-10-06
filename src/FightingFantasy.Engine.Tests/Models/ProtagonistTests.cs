using FightingFantasy.Engine.Models;
using NUnit.Framework;

namespace FightingFantasy.Engine.Tests.Models
{
    [TestFixture]
    public class ProtagonistTests
    {
        [Test]
        public void Protagonist_is_initialised_with_non_null_attributes()
        {
            var protagonist = new Protagonist();

            Assert.That(protagonist.Skill, Is.Not.Null);
        }
    }
}