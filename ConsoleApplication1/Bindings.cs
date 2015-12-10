using Business;
using Business.Interfaces;
using Data.Repositories;
using Ninject.Modules;

namespace ConsoleApplication1
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerManager>().To<CustomerManager>();
            Bind<ICustomerRepository>().To<SqlServerCustomerRepository>();
            //Bind<ICustomerRepository>().To<MySqlCustomerRepository>();
        }
    }
}