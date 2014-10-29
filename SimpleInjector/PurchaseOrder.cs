using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector
{
    public class PurchaseOrder : IOrder
    {
        public void Process()
        {
            Console.WriteLine("Purchase Order processed");
        }
    }
}
