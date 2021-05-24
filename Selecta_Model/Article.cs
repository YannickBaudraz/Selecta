namespace Selecta_Model
{
    /// <summary>
    ///     An article used in the vending machine.
    /// </summary>
    public class Article
    {
        #region Constructors

        /// <summary>
        ///     Instantiate an article with his name, code, quantity and price.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="code">Code for selection</param>
        /// <param name="quantity">Initial quantity</param>
        /// <param name="price">Unit price</param>
        public Article(string name, string code, int quantity, double price)
        {
            Name = name;
            Code = code;
            Quantity = quantity;
            Price = price;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     The name of the article.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     The unique code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        ///     The available quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        ///     The unit price.
        /// </summary>
        public double Price { get; }

        #endregion
    }
}