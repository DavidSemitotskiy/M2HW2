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
            Magazine magazine = new Magazine(new List<Product>
            {
                new Product("Соль", 12.9m),
                new Product("Колбаса", 182.88m),
                new Product("Сахар", 65.1m),
                new Product("Мороженное", 8.12m)
            });
            Console.WriteLine("Список товаров в магазине: ");
            magazine.ShowProducts();
            Console.WriteLine($"Покупатель {user.Name} поместил такие товары в корзину: ");
            List<Product> productsToBasket = new List<Product>();
            int countProducts = rand.Next(1, 11);
            for (int i = 0; i < countProducts; i++)
            {
                productsToBasket.Add(magazine.Products[rand.Next(magazine.Products.Count)]);
            }

            Basket basket = new Basket(productsToBasket);
            basket.ShowProductsInBasket();
            Console.WriteLine("Оформляется заказ...");
            Order order = new Order(basket.Products);
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
