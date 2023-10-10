using Microsoft.AspNetCore.Mvc;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
	
	/// <summary>
	/// Esse teste simula um pagamento de uma compra.
	/// O método PayOrder aceita diversas formas de pagamento. Dentro desse método é feita uma estrutura de diversos "if" para cada um deles.
	/// Sabemos, no entanto, que esse formato não é adequado, em especial para futuras inclusões de formas de pagamento.
	/// Como você reestruturaria o método PayOrder para que ele ficasse mais aderente com as boas práticas de arquitetura de sistemas?
	/// 
	/// Notas: Para resolver esse item e aplicar o principio OCP, eu criei uma classe abstrata que tem o conceito inicial do pagamento, 
	/// e a partir da implementação das classes filhas pix, paypal e creditcard foi possivel resolver tal problema. Futuramente precisando de novas implementalções
	/// basta herdar a classe PaymentService.
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class Parte3Controller :  ControllerBase
	{

        readonly OrderService _orderService;
        public Parte3Controller(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("orders")]
		public async Task<Order> PlaceOrder(string paymentMethod, decimal paymentValue, int customerId)
		{
			return await _orderService.PayOrder(paymentMethod.ToLower(), paymentValue, customerId);
		}
	}
}
