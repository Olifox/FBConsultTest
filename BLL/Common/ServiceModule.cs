using Autofac;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using DAL.Common;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Common
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType<ContactService>().As<IBaseService<ContactDTO>>().InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
