using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class CreditCardPaymentService : PaymentService
    {
        public CreditCardPaymentService(decimal paymentValue, int customerId) : base(paymentValue, customerId)
        {
        }

        public override async Task<Order> PayAsync()
        {
            return await Task.FromResult(new Order()
            {
                Id = 1,
                Value = PaymentValue,
                CustomerId = CustomerId
            });
        }
    }
}
