using Kata.Checkout.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Checkout.Business.Services
{
    public interface IPriceRule
    {
        decimal Calculate(ICollection<CartItem> items);
    }
}
