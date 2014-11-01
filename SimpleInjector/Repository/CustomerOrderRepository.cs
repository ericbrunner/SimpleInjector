using SimpleInjector.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Repository
{
    class CustomerOrderRepository : IRepository<CustomerOrder>
    {
        public void Create(CustomerOrder entity)
        {
            Console.WriteLine("customer-order created.");
        }
    }
}
