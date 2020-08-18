using Autofac;
using FluentValidation.Infra.Helpers.Autofac;
using System.Reflection;

namespace FluentValidation.Data
{
    public class RepositoryRegisterModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope()
               .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterAssemblyComponents(assembly);
        }
    }
}
