using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Repository
{
    public interface IRepository<T>
    {
        void Create(T entity);
    }
}
