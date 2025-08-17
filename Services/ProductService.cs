using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Utils;

namespace ProvaPub.Services
{
	public class ProductService
	{
		TestDbContext _ctx;

		public ProductService(TestDbContext ctx)
		{
			_ctx = ctx;
		}

		public ProductList  ListProducts(int page)
		{
			var response = _ctx.Products.ObterPaginacao(page);

            return new ProductList() {  HasNext=response.hasNext, TotalCount = response.totalCount, Products = response.itens};
		}
    }
}
