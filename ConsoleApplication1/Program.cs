using System;
using System.Linq;
using System.Reflection;
using Business.Interfaces;
using Ninject;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var customerManager = GetCustomerManager();
            var customers = customerManager.GetAllCustomers();
            var duration = customerManager.GetCustomerDuration(customers.FirstOrDefault().Id);

            Console.WriteLine(duration.ToString());
            Console.ReadKey();
        }

        private static ICustomerManager GetCustomerManager()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var customerManager = kernel.Get<ICustomerManager>();
            return customerManager;
        }
    }
}
