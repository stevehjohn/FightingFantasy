using FightingFantasy.Engine.Core;
using FightingFantasy.Engine.Models;
using SimpleInjector;

namespace FightingFantasy.Engine.Infrastructure
{
    public class ContainerManager
    {
        public Container Container { get; }

        public ContainerManager()
        {
            Container = new Container();
        }

        public Container InitialiseContainer()
        {
            Container.RegisterSingleton<IDie, Die>();

            Container.RegisterSingleton<Protagonist>();

            Container.RegisterSingleton<Core.FightingFantasy>();

            return Container;
        }
    }
}