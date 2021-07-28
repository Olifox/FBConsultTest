using Autofac;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<SibersContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType(typeof(AppDbContext)).AsSelf().As(typeof(DbContext)).InstancePerLifetimeScope();

            builder.RegisterType<ContactRepository>().As<IBaseRepository<Contact>>().InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
