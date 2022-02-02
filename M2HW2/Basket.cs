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
        public void ShowProductsInBasket()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Products[i].Name} - {Products[i].Price:C}");
            }

            GetTotalSum();
            Console.WriteLine($"Общая сумма: {TotalSum:C}");
        }

        private void GetTotalSum()
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
