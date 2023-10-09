using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class OrderService
	{

        public OrderService()
        {
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
		{
            var result = paymentMethod switch
            {
                "pix" => await new PixPaymentService(paymentValue, customerId).PayAsync(),
                "paypal" => await new PaypalPaymentService(paymentValue, customerId).PayAsync(),
                "creditcard" => await new CreditCardPaymentService(paymentValue, customerId).PayAsync(),
                _ => throw new InvalidOperationException($"the payment method {paymentMethod} does not exists")
            };

            return result;
		}
	}
}
