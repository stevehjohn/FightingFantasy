using FightingFantasy.Engine.Infrastructure;

namespace FightingFantasy.Engine.Core
{
    public static class FightingFantasyFactory
    {
        public static FightingFantasy Create()
        {
            var containerManager = new ContainerManager();

            var container = containerManager.InitialiseContainer();

            return container.GetInstance<FightingFantasy>();
        }
    }
}