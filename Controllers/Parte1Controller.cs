using Microsoft.AspNetCore.Mvc;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
    /// <summary>
    /// Ao rodar o código abaixo o serviço deveria sempre retornar um número diferente, mas ele fica retornando sempre o mesmo número.
    /// Faça as alterações para que o retorno seja sempre diferente
	/// Para esse item eu alterei a injeção dele, ao inves de AddSingleton (que cria uma instancia do recurso e o reutiliza diversas vezes)
    /// optei pelo uso do AddScoped (que cria uma instancia do recurso para toda vez que o utiliza) para assim resolver o problema.
    /// </summary>
    [ApiController]
	[Route("[controller]")]
	public class Parte1Controller :  ControllerBase
	{
		private readonly RandomService _randomService;

		public Parte1Controller(RandomService randomService)
		{
			_randomService = randomService;
		}
		[HttpGet]
		public int Index()
		{
			return _randomService.GetRandom();
		}
	}
}
