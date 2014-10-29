using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector
{
    public class ShoppingCart
    {
        private readonly IOrder _order;

        public ShoppingCart(IOrder order)
        {
            _order = order;
        }

        public void CheckOut()
        {
            _order.Process();
        }
    }
}
