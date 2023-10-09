using System.Collections.Generic;
using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IProductService
    {
        public Task<Pagination<Product>> ListProducts(int page);
    }
}