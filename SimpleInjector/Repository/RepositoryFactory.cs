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
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly Func<Dictionary<Type, RepositoryBase>> RepoDict2Func;
        private readonly Dictionary<Type, RepositoryBase> RepoDict2;
        public RepositoryFactory(Func<Dictionary<Type, RepositoryBase>> repoDict2Func)
        {
            this.RepoDict2Func = repoDict2Func;
            this.RepoDict2 = this.RepoDict2Func();
        }


        public IRepository<TEntity> CreateNew<TEntity>() 
        {
            return (IRepository<TEntity>)this.RepoDict2[typeof(TEntity)];
        }
    }
}
