using SimpleInjector.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Repository
{
    class CustomerRepository : IRepository<Customer>
    {
        public void Create(Customer entity)
        {
            Console.WriteLine("customer created.");
        }
    }
}
