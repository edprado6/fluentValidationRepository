using Autofac;
using System.Reflection;
using FluentValidation.Data;
using FluentValidation.Infra.Helpers.Autofac;

namespace FluentValidation.Services
{
    public class ServiceRegisterModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Register repository
            builder.RegisterModule(new RepositoryRegisterModule());
                     
            builder.RegisterAssemblyTypes(assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope()
               .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            builder.RegisterAssemblyComponents(assembly);
        }
    }
}
