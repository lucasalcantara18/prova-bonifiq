using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class PaypalPayment : IPaymentMethod
    {
        public string PaymentMethod => "paypal";

        public bool ProcessPayment(decimal paymentValue, int customerId)
        {
            Console.WriteLine($"Processing Paypal payment of {paymentValue} for customer {customerId}.");
            return true;
        }
    }
}
