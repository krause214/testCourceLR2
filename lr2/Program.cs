// See https://aka.ms/new-console-template for more information

using lr2.actor;

Console.WriteLine("Hello");
Manager manager = new Manager();

Buyer buyer = new Buyer(manager);

buyer.OrderCars(1);
buyer.BuyCars();