using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class ProductService : IProductService
	{
        readonly IProductRepository _ctx;

		public ProductService(IProductRepository ctx)
		{
			_ctx = ctx;
		}

		public async Task<Pagination<Product>> ListProducts(int page)
		{
			return await _ctx.ToListAsyncPaginated(page);
		}
    }
}
