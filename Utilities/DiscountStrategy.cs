using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingSystemApp.Utilities
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal amount);
    }

    public class PercentageDiscount : IDiscountStrategy
    {
        private decimal _discountPercentage;

        public PercentageDiscount(decimal discountPercentage)
        {
            _discountPercentage = discountPercentage;
        }

        public decimal ApplyDiscount(decimal amount)
        {
            return amount - (amount * _discountPercentage / 100);
        }
    }

    public class FlatDiscount : IDiscountStrategy
    {
        private decimal _flatDiscountAmount;

        public FlatDiscount(decimal flatDiscountAmount)
        {
            _flatDiscountAmount = flatDiscountAmount;
        }

        public decimal ApplyDiscount(decimal amount)
        {
            return amount - _flatDiscountAmount;
        }
    }
}
