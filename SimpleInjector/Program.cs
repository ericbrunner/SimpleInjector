using SimpleInjector.Repository;
using SimpleInjector.Repository.Base;
using SimpleInjector.Repository.Entity;
using SimpleInjector.Repository.Interfaces;
using SimpleInjector.Repository.RepositoryDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Bootstrap();


            // Usage of registered TServices and there implementations TImplementation

            // uses IOrder registration
            var shoppingChart = container.GetInstance<ShoppingCart>();
            shoppingChart.CheckOut();

            // uses Func<IOrder> registration
            var shoppingChart2 = container.GetInstance<ShoppingCart2>();
            shoppingChart2.CheckOut();

            // uses IShoppingCartFactory registration
            var shoppingCartFactory = container.GetInstance<IShoppingCartFactory>();
            var shoppingCart3 = shoppingCartFactory.CreateNew("private");
            shoppingCart3.CheckOut();

            var shoppingCart4 = shoppingCartFactory.CreateNew("public");
            shoppingCart4.CheckOut();

            // Uncomment to see that Properties are not injected by default. 
            //Console.WriteLine("shoppingChart.ChildShoppingCart not injected = {0}", shoppingChart.ChildShoppingCart == null);

            Console.WriteLine("\nUse Repository Factory for verious generic Repository Types:\n");

            // Use a RepositoryFactory
            var repoFactory = container.GetInstance<IRepositoryFactory>();
            var repoCustomer = repoFactory.CreateNew<Customer>();

            Customer customer = new Customer(); 
            repoCustomer.Create(customer);

            var repoCustomerOrder = repoFactory.CreateNew<CustomerOrder>();

            CustomerOrder customerOrder = new CustomerOrder();
            repoCustomerOrder.Create(customerOrder);
            
            Console.ReadLine();
        }

        private static Container Bootstrap()
        {
            // Instantiate a container
            var container = new SimpleInjector.Container();

            // Register IOrder  
            container.Register<IOrder, PurchaseOrder>();

            // Register a  Func<IOrder>
            container.Register<Func<IOrder>>(() => () => new PurchaseOrder());
            
            // Register all ShoppingCarts
            container.RegisterAll<IShoppingCart>();

            // Register a ShoppingCart Factory
            container.Register<IShoppingCartFactory>(() => new ShoppingCartFactory
            {
                {"private", () => container.GetInstance<ShoppingCart>()},
                {"public", () => container.GetInstance<ShoppingCart2>()}
            });

            // Register all RepositoryDictionaries
            container.RegisterAll<IRepositoryDict>();

            // Register a Dictionary Func
            container.Register<Func<Dictionary<Type, RepositoryBase>>>(() =>
                () => container.GetInstance<RepositoryDictionary>()
                );

            // Register a RepositoryCovariantFactory
            container.Register<IRepositoryFactory, RepositoryFactory>();

            // Verify Container Configuration
            container.Verify();
            return container;
        }
    }
}
