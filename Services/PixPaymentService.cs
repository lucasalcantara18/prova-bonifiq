using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class PixPaymentService : IPaymentMethod
    {
        public string PaymentMethod => "pix";

        public bool ProcessPayment(decimal paymentValue, int customerId)
        {
            Console.WriteLine($"Processing Pix payment of {paymentValue} for customer {customerId}.");
            return true;
        }
    }
}
