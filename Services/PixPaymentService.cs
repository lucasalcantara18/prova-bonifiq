using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class PixPaymentService : PaymentService
    {
        public PixPaymentService(decimal paymentValue, int customerId) : base(paymentValue, customerId)
        {
        }

        public override async Task<Order> PayAsync()
        {
            return await Task.FromResult(new Order()
            {
                Id = 3,
                Value = PaymentValue,
                CustomerId = CustomerId
            });
        }
    }
}
