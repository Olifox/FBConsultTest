using Autofac;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System.Data.Entity;

namespace DAL.Common
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>().AsSelf();

            builder.RegisterType<ContactRepository>().As<IBaseRepository<Contact>>().InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
