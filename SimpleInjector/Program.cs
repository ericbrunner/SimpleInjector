using SimpleInjector.Repository;
using SimpleInjector.Repository.Base;
using SimpleInjector.Repository.Entity;
using SimpleInjector.Repository.Interfaces;
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


            // Use a RepositoryFactory
            var repoFactory = container.GetInstance<IRepositoryFactory>();
            
            Customer cust = new Customer();
            var custrepo = repoFactory.CreateNew<Customer>();
            custrepo.Create(cust);

            CustomerOrder custOrder = new CustomerOrder();
            var custOrderRepo = repoFactory.CreateNew<CustomerOrder>();
            custOrderRepo.Create(custOrder);

            // Use a RepositoryCovariantFactory
            var repoCoVariantFactory = container.GetInstance<IRepositoryCoVarianceFactory>();

            RepositoryBase repo = repoCoVariantFactory.CreateNew("customer_repo").GetRepository();
            CustomerRepository custRepository = repo as CustomerRepository;
            custRepository.Create(cust);

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
            container.RegisterAll<IShoppingCart>();

            // Register a ShoppingCart Factory
            container.Register<IShoppingCartFactory>(() => new ShoppingCartFactory
            {
                {"private", () => container.GetInstance<ShoppingCart>()},
                {"public", () => container.GetInstance<ShoppingCart2>()}
            });

            // Register a CustomerRepository and CustomerOrderRepository Func
            container.Register<Func<IRepository<Customer>>>(() => () => new CustomerRepository());
            container.Register<Func<IRepository<CustomerOrder>>>(() => () => new CustomerOrderRepository());
            
            // Register a RepositoryFactory (uses the above Func)
            container.Register<IRepositoryFactory, RepositoryFactory>();


            // Register a Dictionary Func
            container.Register<Func<Dictionary<string, IRepositoryCoVariance<RepositoryBase>>>>(() =>
                () => new Dictionary<string, IRepositoryCoVariance<RepositoryBase>>{
                    {"customer_repo", new CustomerRepositoryCoVariant()}
                });

            // Register a RepositoryCovariantFactory
            container.Register<IRepositoryCoVarianceFactory, RepositoryCoVariantFactory>();
            

            // Verify Container Configuration
            container.Verify();
            return container;
        }
    }
}
