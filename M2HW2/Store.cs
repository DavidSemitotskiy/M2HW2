using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Store
    {
        public Store(List<Product> products)
        {
            Products = new List<Product>(products);
        }

        public List<Product> Products { get; private set; }

        public bool Checkout(Order order, User user)
        {
            if (user.Money < order.TotalSum)
            {
                return false;
            }

            user.Pay(order.TotalSum);
            order.ChangeStatusPaid();
            return true;
        }
    }
}
