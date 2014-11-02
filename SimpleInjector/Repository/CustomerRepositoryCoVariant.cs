using SimpleInjector.Repository.Entity;
using SimpleInjector.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Repository
{
    class CustomerRepositoryCoVariant : IRepositoryCoVariance<CustomerRepository>
    {
        public CustomerRepository GetRepository()
        {
            return new CustomerRepository();
        }
    }
}
