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
                Dictionary<string, int> itemRecord = new Dictionary<string, int>();

                

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
                    

                    /*bool addCostToElBike = itemRecord.ContainsKey("electric bicycle");
                    bool addCostTotrampoline = itemRecord.ContainsKey("trampoline");
                    bool addCostTobouquet = itemRecord.ContainsKey("bouquet");

                    itemRecord["electric bicycle"] = 100;
                    itemRecord["trampoline"] = 200;
                    itemRecord["bouquet"] = 300;

                    addCostToElBike = itemRecord.ContainsKey("electric bicycle");
                    addCostTotrampoline = itemRecord.ContainsKey("trampoline");
                    addCostTobouquet = itemRecord.ContainsKey("bouquet");*/



                    int orderCount = 0;

                    foreach (var order in orders)
                    {
                       
                       if (itemRecord.ContainsKey(order.Name))//Finns ordernamnet? Ja? lägg till en, Nej? lägg till i dictionary
                       {
                           itemRecord[order.Name] += 1;
                       }
                       else
                       {
                           itemRecord[order.Name] = 1;
                       }
                        // lägg till ett för varje gång en vara dyker upp
                    }

                    foreach (var record in itemRecord)
                    {
                        
                          
                         Console.WriteLine("item: "+ record.Key + "amount: " + record.Value);
                        
                    }
                    Console.ReadLine();
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
