using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector.Repository.Entity;
using SimpleInjector.Repository.Interfaces;

namespace SimpleInjector.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly Func<IRepository<Customer>> customerFunc;
        private readonly Func<IRepository<CustomerOrder>> custOrderFunc;

        public RepositoryFactory(
            Func<IRepository<Customer>> custFunc,
            Func<IRepository<CustomerOrder>> custOrderFunc)
        {
            this.customerFunc = custFunc;
            this.custOrderFunc = custOrderFunc;
        }

        public IRepository<T> CreateNew<T>()
        {
            if (typeof(T) == typeof(Customer))
                return (IRepository<T>)customerFunc();

            if (typeof(T) == typeof(CustomerOrder))
                return (IRepository<T>)custOrderFunc();

            return null;
        }

    }
}
