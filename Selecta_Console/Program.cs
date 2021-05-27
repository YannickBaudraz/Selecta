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
            AssertExtension();
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

        private static void AssertExtension()
        {
            Console.WriteLine("Extension assertion");
            var vendingMachine = new VendingMachine(new List<Article>
            {
                new Article("Smarlies", "A01", 100, 1.60),
                new Article("Carampar", "A02", 50, 0.60),
                new Article("Avril", "A03", 20, 2.10),
                new Article("KokoKola", "A04", 10, 2.95)
            });
            vendingMachine.Insert(1000.00);

#if DEBUG
            SetTime("2020-01-01T20:30:00");
            vendingMachine.Choose("A01");

            SetTime("2020-03-01T23:30:00");
            vendingMachine.Choose("A01");

            SetTime("2020-03-04T09:22:00");
            vendingMachine.Choose("A01");

            SetTime("2020-04-01T23:00:00");
            vendingMachine.Choose("A01");

            SetTime("2020-04-01T23:59:59");
            vendingMachine.Choose("A01");

            SetTime("2020-04-04T09:12:00");
            vendingMachine.Choose("A01");

            // Add this to have 4 different hours and be sure to only take 3.
            SetTime("2020-04-04T07:12:00");
            vendingMachine.Choose("A02");
#else
            vendingMachine.Choose("A01");
            vendingMachine.Choose("A01");
            vendingMachine.Choose("A01");
            vendingMachine.Choose("A01");
            vendingMachine.Choose("A01");
            vendingMachine.Choose("A01");
#endif

            foreach (StatsLine statsLine in vendingMachine.GetBestHoursBySales())
                Console.WriteLine("Hour {0} generated a revenue of {1:C}", statsLine.Hour, statsLine.TotalAmount);

            Console.WriteLine();
        }

        private static void SetTime(string timeString)
        {
            FakeTime.Current = DateTime.Parse(timeString);
        }
    }
}