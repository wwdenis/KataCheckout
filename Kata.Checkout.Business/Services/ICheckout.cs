using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Checkout.Business.Services
{
    public interface ICheckout
    {
        decimal Calculate();
        void Scan(string sku);
    }
}
