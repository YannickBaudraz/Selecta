namespace Selecta_Model
{
    /// <summary>
    ///     This interface is designed to represent a line of stats.
    /// </summary>
    public class StatsLine
    {
        #region Constructors

        /// <summary>
        ///     Instantiate a line of stats.
        /// </summary>
        /// <param name="hour">The hours of the line.</param>
        /// <param name="totalAmount">The total amount by hour.</param>
        public StatsLine(int hour, double totalAmount)
        {
            Hour = hour;
            TotalAmount = totalAmount;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     The hour of the line.
        /// </summary>
        public int Hour { get; }

        /// <summary>
        ///     The total amount by hour.
        /// </summary>
        public double TotalAmount { get; }

        #endregion
    }
}