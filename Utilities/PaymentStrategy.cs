using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InvoicingSystemApp.Utilities
{
    public interface IPaymentStrategy
    {
        void ProcessPayment(decimal amount);
    }

    public class CreditCardPayment : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            // Implement credit card payment processing logic
            // For example:
            // Console.WriteLine($"Processing credit card payment of {amount}...");
        }
    }

    public class CashPayment : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            // Implement cash payment processing logic
            // For example:
            // Console.WriteLine($"Received cash payment of {amount}...");
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            // Implement PayPal payment processing logic
            // For example:
            // Console.WriteLine($"Processing PayPal payment of {amount}...");
        }
    }
}
