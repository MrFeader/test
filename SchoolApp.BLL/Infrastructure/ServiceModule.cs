using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using SchoolApp.DAL.Interfaces;
using SchoolApp.DAL.Repositories;

namespace SchoolApp.BLL.Infrastructure
{
    public class ServiceModule:NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
