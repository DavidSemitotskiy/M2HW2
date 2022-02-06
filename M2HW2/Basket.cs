using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Basket
    {
        public Basket(List<Product> products)
        {
            Products = new List<Product>(products);
        }

        public List<Product> Products { get; private set; }
        public decimal TotalSum { get; private set; }

        public void GetTotalSum()
        {
            decimal sum = 0m;
            foreach (var product in Products)
            {
                sum += product.Price;
            }

            TotalSum = sum;
        }
    }
}
