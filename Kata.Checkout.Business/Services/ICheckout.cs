using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Checkout.Business.Services
{
    /// <summary>
    /// Defines a contract for a generic Checkout system.
    /// </summary>
    public interface ICheckout
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The total price of all items</returns>
        decimal Calculate();

        /// <summary>
        /// Adds a Product to the scanned list
        /// </summary>
        /// <param name="sku"></param>
        void Scan(string sku);
    }
}
