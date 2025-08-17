using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class CreditCardPaymentService : IPaymentMethod
    {
        public string PaymentMethod => "creditcard";

        public bool ProcessPayment(decimal paymentValue, int customerId)
        {
            Console.WriteLine($"Processing Credit Card payment of {paymentValue} for customer {customerId}.");
            return true;
        }
    }
}
