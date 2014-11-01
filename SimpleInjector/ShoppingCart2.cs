using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector
{
    public class ShoppingCart2 : IShoppingCart
    {
        private readonly Func<IOrder> _order;

        public ShoppingCart2(Func<IOrder> order)
        {
            _order = order;
        }

        public void CheckOut()
        {
            Console.WriteLine(this.GetType().Name + " gets checked out ...");
            _order().Process();
        }
    }
}
