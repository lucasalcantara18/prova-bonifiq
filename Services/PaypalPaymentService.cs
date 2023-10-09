using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class PaypalPaymentService : PaymentService
    {
        public PaypalPaymentService(decimal paymentValue, int customerId) : base(paymentValue, customerId)
        {
        }

        public override async Task<Order> PayAsync()
        {
            return await Task.FromResult(new Order()
            {
                Id = 2,
                Value = PaymentValue,
                CustomerId = CustomerId
            });
        }
    }
}
