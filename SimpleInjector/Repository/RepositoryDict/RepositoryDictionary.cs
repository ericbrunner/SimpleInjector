using SimpleInjector.Repository.Base;
using SimpleInjector.Repository.Entity;
using SimpleInjector.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Repository.RepositoryDict
{
    class RepositoryDictionary : Dictionary<Type, RepositoryBase>, IRepositoryDict
    {
        public RepositoryDictionary()
        {
            this.Add(typeof(Customer), new CustomerRepository());
            this.Add(typeof(CustomerOrder), new CustomerOrderRepository());
        }
    }
}
