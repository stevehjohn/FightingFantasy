using FightingFantasy.Engine.Infrastructure;

namespace FightingFantasy.Engine.Core
{
    public static class FightingFantasyFactory
    {
        public static FightingFantasy Create()
        {
            var container = ContainerManager.InitialiseContainer();

            return container.GetInstance<FightingFantasy>();
        }
    }
}