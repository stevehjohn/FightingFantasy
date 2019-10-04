using FightingFantasy.Engine.Infrastructure;
using NUnit.Framework;

namespace FightingFantasy.Engine.Tests.Infrastructure
{
    [TestFixture]
    public class ContainerManagerTests
    {
        [Test]
        public void Container_can_initialise_all_objects()
        {
            var containerManager = new ContainerManager();

            var container = containerManager.InitialiseContainer();

            Assert.DoesNotThrow(() => container.Verify());
        }
    }
}