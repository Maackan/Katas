using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OnlineOrderSystem
{
    class Program
    {
        private static List<OnlineOrder> orders;
        static void Main(string[] args)
        {
            orders = new List<OnlineOrder>();
            EnterMainLoop();
        }

        static void EnterMainLoop()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("1: Order an electric bicycle");
                Console.WriteLine("2: Order a trampoline");
                Console.WriteLine("3: Order a bouquet");
                Console.WriteLine("4: Order something else");
                Console.WriteLine("5: Show all orders");
                Console.WriteLine("6: Show amount of each order");
                Console.WriteLine("7: Exit");

                Console.Write("Type option and press enter:");
                int choice = int.Parse(Console.ReadLine());

                Console.Clear();

                if (choice == 1)
                {
                    orders.Add(new OnlineOrder("electric bicycle"));
                }
                else if (choice == 2)
                {
                    orders.Add(new OnlineOrder("trampoline"));
                }
                else if (choice == 3)
                {
                    orders.Add(new OnlineOrder("bouquet"));
                }
                else if (choice == 4)
                {
                    Console.Write("Type in order: ");
                    string articleName = Console.ReadLine();
                    orders.Add(new OnlineOrder(articleName));
                }
                else if (choice == 6)
                {
                    // TODO lägg till en dictionary itemRecord som har nyckeltyp 'string' och värdetyp 'int'

                    foreach (var order in orders)
                    {
                        
                    }

                    //foreach (var record in itemRecord)
                    {
                        
                    }
                    Console.WriteLine("6: Show amount of each order");
                }
                else if (choice == 7)
                {
                    break;
                }
            }
        }
    }
}
