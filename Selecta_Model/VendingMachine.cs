using System;
using System.Collections.Generic;

namespace Selecta_Model
{
    /// <summary>
    ///     The vending machine used in the program.
    /// </summary>
    public class VendingMachine
    {
        #region Constructors

        /// <summary>
        ///     Instantiate a vending machine with an articles list.
        /// </summary>
        /// <param name="articles">The articles list.</param>
        public VendingMachine(List<Article> articles)
        {
            _articles = articles;
            Balance = 0;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     The current selection credit amount.
        /// </summary>
        public double Change { get; private set; }

        /// <summary>
        ///     The total of amount collected by the machine.
        /// </summary>
        public double Balance { get; private set; }

        private readonly List<Article> _articles;

        #endregion

        #region Methods

        /// <summary>
        ///     Add credit amount for selection.
        /// </summary>
        /// <param name="amount">The amount to add.</param>
        public void Insert(double amount)
        {
            Change += amount;
        }

        /// <summary>
        ///     Ask an article an return a message corresponding to the result.
        /// </summary>
        /// <param name="code">The code of the article.</param>
        /// <returns>A message indicating the result of the operation.</returns>
        public string Choose(string code)
        {
            string message;

            try
            {
                Article articleChose = _articles.Find(article => article.Code == code);
                if (Change < articleChose.Price)
                {
                    message = "Not enough money!";
                }
                else if (articleChose.Quantity <= 0)
                {
                    message = $"Item {articleChose.Name}: Out of stock!";
                }
                else
                {
                    Change -= articleChose.Price;
                    Balance += articleChose.Price;
                    articleChose.Quantity--;
                    message = $"Vending {articleChose.Name}";
                }
            }
            catch (NullReferenceException)
            {
                message = "Invalid selection!";
            }

            return message;
        }

        #endregion
    }
}