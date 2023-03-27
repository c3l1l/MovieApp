using Autofac;
using Movie.Core.Repositories;
using Movie.Core.Services;
using Movie.Core.UnitOfWorks;
using Movie.Repository.DbContexts;
using Movie.Repository.Repositories;
using Movie.Repository.UnitOfWork;
using Movie.Service.Mapping;
using Movie.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace Movie.API.Modules
{
    //Autofac
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext)); //Herhangi bir dosya adi ile o dosyanin icinde bulundugu assembly alinir.
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
