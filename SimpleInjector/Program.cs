using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new SimpleInjector.Container();
            container.Register<IOrder, PurchaseOrder>();

            var shoppingChart = container.GetInstance<ShoppingCart>();
            shoppingChart.CheckOut();

            Console.ReadLine();
        }
    }
}
