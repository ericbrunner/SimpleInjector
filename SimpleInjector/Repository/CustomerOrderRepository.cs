using SimpleInjector.Repository.Base;
using SimpleInjector.Repository.Entity;
using SimpleInjector.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Repository
{
    class CustomerOrderRepository : RepositoryBase, IRepository<CustomerOrder>
    {
        public void Create(CustomerOrder entity)
        {
            Console.WriteLine("customer-order created.");
        }
    }
}
