using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public static class Starter
    {
        public static void RunProgram()
        {
            Random rand = new Random();
            User user = new User("David", 672.9m);
            Store magazine = new Store(new List<Product>
            {
                new Product("Соль", 12.9m),
                new Product("Колбаса", 182.88m),
                new Product("Сахар", 65.1m),
                new Product("Мороженное", 8.12m)
            });
            Console.WriteLine("Список товаров в магазине: ");
            for (int i = 0; i < magazine.Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {magazine.Products[i].Name} - {magazine.Products[i].Price:C}");
            }

            Console.WriteLine($"Покупатель {user.Name} поместил такие товары в корзину: ");
            List<Product> productsToBasket = new List<Product>();
            int countProducts = rand.Next(1, 11);
            for (int i = 0; i < countProducts; i++)
            {
                productsToBasket.Add(magazine.Products[rand.Next(magazine.Products.Count)]);
            }

            Basket basket = new Basket(productsToBasket);
            for (int i = 0; i < basket.Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {basket.Products[i].Name} - {basket.Products[i].Price:C}");
            }

            basket.GetTotalSum();
            Console.WriteLine($"Общая сумма: {basket.TotalSum:C}");
            Console.WriteLine("Оформляется заказ...");
            Order order = new Order(basket.Products);
            Console.WriteLine("Чек: ");
            Console.WriteLine($"Id заказа: {order.IdOrder}");
            Console.WriteLine($"Id - {user.IdUser} : Name - {user.Name}");
            for (int i = 0; i < order.Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {order.Products[i].Name} - {order.Products[i].Price:C}");
            }

            Console.WriteLine($"Общая сумма - {order.TotalSum:C}");
            if (magazine.Checkout(order, user))
            {
                Console.WriteLine("Заказ успешно оплачен");
                Console.WriteLine($"Оставшееся количество денег на счету: {user.Money:C}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счету!!");
            }

            string statusOrder = order.IsPaid ? "Оплачен" : "Не оплачен";
            Console.WriteLine($"Состояние заказа - {statusOrder}");
        }
    }
}
