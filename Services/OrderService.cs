using Microsoft.EntityFrameworkCore;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Utils;

namespace ProvaPub.Services
{
	public class OrderService
	{
        TestDbContext _ctx;
		private readonly IEnumerable<IPaymentMethod> _paymentMethods;

        public OrderService(TestDbContext ctx, IEnumerable<IPaymentMethod> paymentMethods)
        {
            _ctx = ctx;
            _paymentMethods = paymentMethods;
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
		{
            var method = _paymentMethods
            .FirstOrDefault(p => p.PaymentMethod.Equals(paymentMethod, StringComparison.OrdinalIgnoreCase));

            if (method == null)
				throw new ArgumentException("Método de pagamento inválido.");

			var statusPayment = method.ProcessPayment(paymentValue, customerId);

            if(!statusPayment)
                throw new InvalidOperationException("Erro ao processar o pagamento.");

            var newOrder = await InsertOrder(new Order()
            {
                Value = paymentValue,
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow
            });

            _ctx.SaveChanges();

            return newOrder.NormalizeTimezone();//Retorna o pedido para o controller
        }

		public async Task<Order> InsertOrder(Order order)
        {
			//Insere pedido no banco de dados
			return (await _ctx.Orders.AddAsync(order)).Entity;
        }
	}
}
