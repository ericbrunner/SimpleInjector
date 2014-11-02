using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Repository.Interfaces
{
    interface IRepositoryFactory
    {
        IRepository<T> CreateNew<T>();
    }
}
