using System;
using System.Collections.Generic;
using Selecta_Model;

namespace Selecta_Console
{
    internal static class Program
    {
        private static void Main()
        {
            Assert1();
            Assert2();
            Assert3();
            Assert4();
            Assert5();
            Assert6();
            Assert7();
            Console.Write("Press on a key...");
            Console.ReadKey();
        }

        private static void Assert1()
        {
            Console.WriteLine("Assertion N°1");
            VendingMachine vendingMachine = CreateMachine();

            vendingMachine.Insert(3.40);
            Console.WriteLine("Inserted 3.40");
            Console.WriteLine(vendingMachine.Choose("A01"));
            Console.WriteLine("Change : {0:C}", vendingMachine.Change);

            Console.WriteLine();
        }

        private static void Assert2()
        {
            Console.WriteLine("Assertion N°2");
            VendingMachine vendingMachine = CreateMachine();

            vendingMachine.Insert(2.10);
            Console.WriteLine("Inserted 2.10");
            Console.WriteLine(vendingMachine.Choose("A03"));
            Console.WriteLine("Change : {0:C}", vendingMachine.Change);
            Console.WriteLine("Balance : {0:C}", vendingMachine.Balance);

            Console.WriteLine();
        }

        private static void Assert3()
        {
            Console.WriteLine("Assertion N°3");
            VendingMachine vendingMachine = CreateMachine();

            Console.WriteLine(vendingMachine.Choose("A01"));

            Console.WriteLine();
        }

        private static void Assert4()
        {
            Console.WriteLine("Assertion N°4");
            VendingMachine vendingMachine = CreateMachine();

            vendingMachine.Insert(1.00);
            Console.WriteLine("Inserted 1.00");
            Console.WriteLine(vendingMachine.Choose("A01"));
            Console.WriteLine("Change : {0:C}", vendingMachine.Change);
            Console.WriteLine(vendingMachine.Choose("A02"));
            Console.WriteLine("Change : {0:C}", vendingMachine.Change);

            Console.WriteLine();
        }

        private static void Assert5()
        {
            Console.WriteLine("Assertion N°5");
            VendingMachine vendingMachine = CreateMachine();

            vendingMachine.Insert(1.00);
            Console.WriteLine("Inserted 1.00");
            Console.WriteLine(vendingMachine.Choose("A05"));

            Console.WriteLine();
        }

        private static void Assert6()
        {
            Console.WriteLine("Assertion N°6");
            VendingMachine vendingMachine = CreateMachine();

            vendingMachine.Insert(6.00);
            Console.WriteLine("Inserted 6.00");
            Console.WriteLine(vendingMachine.Choose("A04"));
            Console.WriteLine(vendingMachine.Choose("A04"));
            Console.WriteLine("Change : {0:C}", vendingMachine.Change);

            Console.WriteLine();
        }

        private static void Assert7()
        {
            Console.WriteLine("Assertion N°7");
            VendingMachine vendingMachine = CreateMachine();

            vendingMachine.Insert(6.00);
            Console.WriteLine("Inserted 6.00");
            Console.WriteLine(vendingMachine.Choose("A04"));
            vendingMachine.Insert(6.00);
            Console.WriteLine("Inserted 6.00");
            Console.WriteLine(vendingMachine.Choose("A04"));
            Console.WriteLine(vendingMachine.Choose("A01"));
            Console.WriteLine(vendingMachine.Choose("A02"));
            Console.WriteLine(vendingMachine.Choose("A02"));
            Console.WriteLine("Change : {0:C}", vendingMachine.Change);
            Console.WriteLine("Balance : {0:C}", vendingMachine.Balance);

            Console.WriteLine();
        }

        private static VendingMachine CreateMachine()
        {
            return new VendingMachine(new List<Article>
            {
                new Article("Smarlies", "A01", 10, 1.60),
                new Article("Carampar", "A02", 5, 0.60),
                new Article("Avril", "A03", 2, 2.10),
                new Article("KokoKola", "A04", 1, 2.95)
            });
        }
    }
}