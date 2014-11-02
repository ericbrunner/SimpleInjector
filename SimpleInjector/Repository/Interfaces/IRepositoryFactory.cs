using SimpleInjector.Repository.Base;
using SimpleInjector.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Repository.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> CreateNew<TEntity>();
    }
}
