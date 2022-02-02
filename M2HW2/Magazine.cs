using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Magazine
    {
        public Magazine(List<Product> products)
        {
            Products = new List<Product>(products);
        }

        public List<Product> Products { get; private set; }
        public void ShowProducts()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Products[i].Name} - {Products[i].Price:C}");
            }
        }

        public bool Checkout(Order order, User user)
        {
            order.ShowOrder(user);
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
