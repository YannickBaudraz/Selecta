using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selecta_Model;

namespace Selecta_Test
{
    [TestClass]
    public class VendingMachineTest
    {
        private VendingMachine _vendingMachine;

        [TestInitialize]
        public void Init()
        {
            var articles = new List<Article>
            {
                new Article("Smarlies", "A01", 10, 1.60),
                new Article("Carampar", "A02", 5, 0.60),
                new Article("Avril", "A03", 2, 2.10),
                new Article("KokoKola", "A04", 1, 2.95)
            };

            _vendingMachine = new VendingMachine(articles);
        }

        [TestMethod]
        public void Choose_AmountInserted_ActualChange()
        {
            _vendingMachine.Insert(3.40);
            Assert.AreEqual(_vendingMachine.Choose("A01"), "Vending Smarlies");
            Assert.AreEqual(Math.Round(_vendingMachine.Change, 2), 1.80);
        }

        [TestMethod]
        public void Choose_AmountInserted_ActualBalance()
        {
            _vendingMachine.Insert(2.10);
            Assert.AreEqual(_vendingMachine.Choose("A03"), "Vending Avril");
            Assert.AreEqual(Math.Round(_vendingMachine.Change, 2), 0.00);
            Assert.AreEqual(Math.Round(_vendingMachine.Balance, 2), 2.10);
        }

        [TestMethod]
        public void Choose_NotEnoughAmount_ErrorMessage()
        {
            Assert.AreEqual(_vendingMachine.Choose("A01"), "Not enough money!");
        }

        [TestMethod]
        public void Choose_ErrorAndChooseAnother_Success()
        {
            _vendingMachine.Insert(1.00);
            Assert.AreEqual(_vendingMachine.Choose("A01"), "Not enough money!");
            Assert.AreEqual(Math.Round(_vendingMachine.Change, 2), 1.00);
            Assert.AreEqual(_vendingMachine.Choose("A02"), "Vending Carampar");
            Assert.AreEqual(Math.Round(_vendingMachine.Change, 2), 0.40);
        }

        [TestMethod]
        public void Choose_InvalidSelection_ErrorMessage()
        {
            _vendingMachine.Insert(1.00);
            Assert.AreEqual(_vendingMachine.Choose("A05"), "Invalid selection!");
        }

        [TestMethod]
        public void Choose_ArticleOutOfStock_ErrorMessage()
        {
            _vendingMachine.Insert(6.00);
            Assert.AreEqual(_vendingMachine.Choose("A04"), "Vending KokoKola");
            Assert.AreEqual(_vendingMachine.Choose("A04"), "Item KokoKola: Out of stock!");
            Assert.AreEqual(Math.Round(_vendingMachine.Change, 2), 3.05);
        }

        [TestMethod]
        public void Choose_BigTest_MultipleResults()
        {
            _vendingMachine.Insert(6.00);
            Assert.AreEqual(_vendingMachine.Choose("A04"), "Vending KokoKola");
            _vendingMachine.Insert(6.00);
            Assert.AreEqual(_vendingMachine.Choose("A04"), "Item KokoKola: Out of stock!");
            Assert.AreEqual(_vendingMachine.Choose("A01"), "Vending Smarlies");
            Assert.AreEqual(_vendingMachine.Choose("A02"), "Vending Carampar");
            Assert.AreEqual(_vendingMachine.Choose("A02"), "Vending Carampar");
            Assert.AreEqual(Math.Round(_vendingMachine.Change, 2), 6.25);
            Assert.AreEqual(Math.Round(_vendingMachine.Balance, 2), 5.75);
        }
    }
}