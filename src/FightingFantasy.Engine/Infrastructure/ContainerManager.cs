using FightingFantasy.Engine.Core;
using FightingFantasy.Engine.Models;
using SimpleInjector;

namespace FightingFantasy.Engine.Infrastructure
{
    public static class ContainerManager
    {
        public static Container Container { get; }

        static ContainerManager()
        {
            Container = new Container();
        }

        public static Container InitialiseContainer()
        {
            Container.RegisterSingleton<IDie, Die>();

            Container.RegisterSingleton<Protagonist>();

            Container.RegisterSingleton<Core.FightingFantasy>();

            return Container;
        }
    }
}