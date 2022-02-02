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

        public void ShowOrder(User user)
        {
            Console.WriteLine("Чек: ");
            Console.WriteLine($"Id заказа: {IdOrder}");
            Console.WriteLine($"Id - {user.IdUser} : Name - {user.Name}");
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Products[i].Name} - {Products[i].Price:C}");
            }

            Console.WriteLine($"Общая сумма - {TotalSum:C}");
        }
    }
}
