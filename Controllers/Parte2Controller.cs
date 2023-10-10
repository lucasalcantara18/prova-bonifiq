using Microsoft.AspNetCore.Mvc;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
	
	[ApiController]
	[Route("[controller]")]
	public class Parte2Controller :  ControllerBase
	{
        /// <summary>
        /// Precisamos fazer algumas alterações:
        /// 1 - Não importa qual page é informada, sempre são retornados os mesmos resultados. Faça a correção.
		/// 
		/// Notas: Para esse item eu adicionei na busca do banco as tratativas para contemplar corretamente a paginação: .Skip((page - 1) * 10).Take(10).
		/// 
        /// 2 - Altere os códigos abaixo para evitar o uso de "new", como em "new ProductService()". Utilize a Injeção de Dependência para resolver esse problema
		/// 
		/// Notas: Para resolver esse item eu adicionei uma interface e usei a implementação existente para injetar esses serviços através da injeção de depêndencia
		/// 
        /// 3 - Dê uma olhada nos arquivos /Models/CustomerList e /Models/ProductList. Veja que há uma estrutura que se repete. 
		/// 
		/// Notas: Para esse item eu criei uma estrutura generica de paginação (ver arquivo: Pagination) para poder resolver o problema de repetição do código
		/// 
        /// Como você faria pra criar uma estrutura melhor, com menos repetição de código? E quanto ao CustomerService/ProductService. Você acha que seria possível evitar a repetição de código?
		/// 
		/// Notas: Quanto a estes itens, eu implementei um esquema de Repository Pattern para poder melhorar a repetição de buscas e centralizar o acesso ao banco a esses repositorios e consequentimente a injeção de dependencia
        /// 
        /// </summary>
        readonly IProductService _productService;
        readonly ICustomerService _customerService;
        public Parte2Controller(IProductService productService, ICustomerService customerService)
		{
			_productService = productService;
			_customerService = customerService;
		} 
	
		[HttpGet("products")]
		public async Task<Pagination<Product>> ListProductsAsync(int page = 1)
		{
			return await _productService.ListProducts(page);
		}

		[HttpGet("customers")]
		public async Task<Pagination<Customer>> ListCustomersAsync(int page = 1)
		{
			return await _customerService.ListCustomers(page);
		}
	}
}
