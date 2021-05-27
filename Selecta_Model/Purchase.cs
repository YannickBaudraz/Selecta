using System;

namespace Selecta_Model
{
    /// <summary>
    ///     A purchase.
    /// </summary>
    public class Purchase
    {
        #region Constructors

        /// <summary>
        ///     Instantiate a purchase with his amount.
        /// </summary>
        /// <param name="amount">The amount of the purchase.</param>
        public Purchase(double amount)
        {
#if DEBUG
            DateTime = FakeTime.Current;
#else
            DateTime = DateTime.Now;
#endif
            Amount = amount;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     The time when the purchase is created.
        /// </summary>
        public DateTime DateTime { get; }

        /// <summary>
        ///     The amount of the purchase.
        /// </summary>
        public double Amount { get; }

        #endregion
    }
}