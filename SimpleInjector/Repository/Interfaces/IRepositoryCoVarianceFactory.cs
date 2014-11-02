using SimpleInjector.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Repository.Interfaces
{
    public interface IRepositoryCoVarianceFactory
    {
        IRepositoryCoVariance<RepositoryBase> CreateNew(string repoName);
    }
}
