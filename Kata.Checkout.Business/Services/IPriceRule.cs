using Kata.Checkout.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Checkout.Business.Services
{
    /// <summary>
    /// Defines a contract for a generic price calculation
    /// </summary>
    public interface IPriceRule
    {
        /// <summary>
        /// Calculates the total price based in the selected items
        /// </summary>
        /// <param name="items">A collection of scanned items.</param>
        /// <returns>The total price of the scanned itens.</returns>
        decimal Calculate(ICollection<CartItem> items);
    }
}
