using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Order
    {
        public Order(List<Product> products)
        {
            Products = new List<Product>(products);
            foreach (var product in Products)
            {
                TotalSum += product.Price;
            }
        }

        public List<Product> Products { get; }
        public decimal TotalSum { get; }
        public Guid IdOrder { get; } = Guid.NewGuid();

        public bool IsPaid { get; private set; } = false;
        public void ChangeStatusPaid()
        {
            IsPaid = true;
        }
    }
}
