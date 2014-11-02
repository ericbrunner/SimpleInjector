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
    public class RepositoryCoVariantFactory : IRepositoryCoVarianceFactory
    {
        private readonly Func<Dictionary<string, IRepositoryCoVariance<RepositoryBase>>> RepoDictFunc;
        private readonly Dictionary<string, IRepositoryCoVariance<RepositoryBase>> RepoDict;
        public RepositoryCoVariantFactory(Func<Dictionary<string, IRepositoryCoVariance<RepositoryBase>>> repoDictFunc)
        {
            this.RepoDictFunc = repoDictFunc;
            this.RepoDict = this.RepoDictFunc();
        }
        // CreateNew<CustomerRepository>
        public IRepositoryCoVariance<RepositoryBase> CreateNew(string repoName)
        {
            return this.RepoDict[repoName];
        }
    }
}
