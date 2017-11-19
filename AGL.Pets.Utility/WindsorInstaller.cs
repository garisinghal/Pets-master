using Pets.Common.Interfaces;
using Pets.Utility.Data;
using Pets.Utility.Repositories;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Pets.Utility
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Component.For<IPersonRepository>().ImplementedBy<PersonRepository>());
#if DEBUG
            container.Register(Component.For<IDataContext>().ImplementedBy<FakeDataContext>());
#else
            container.Register(Component.For<IDataContext>().ImplementedBy<DataContext>());
#endif
        }
    }
}
