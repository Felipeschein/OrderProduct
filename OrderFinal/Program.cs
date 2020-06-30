using System;
using System.Globalization;
using OrderFinal.Entities;
using OrderFinal.Entities.Enums;

namespace OrderFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, date);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; n >= i; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string ProdName = Console.ReadLine();
                Console.Write("Product price: ");
                double ProdPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(ProdName, ProdPrice);

                Console.Write("Quantity: ");
                int qtd = int.Parse(Console.ReadLine());
                                         
                OrderItem orderItem = new OrderItem(qtd, ProdPrice, product);
                order.AddItem(orderItem);
            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);


        }
    }
}
