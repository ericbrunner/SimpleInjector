using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector
{
    class ShoppingCartFactory: Dictionary<string, Func<IShoppingCart>>, IShoppingCartFactory
    {
        public IShoppingCart CreateNew(string shoppingCartId)
        {
            return this[shoppingCartId]();
        }
    }
}
