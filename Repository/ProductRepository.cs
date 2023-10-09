using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace Infrastructure.DataAccess.Repositories.Entities
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(TestDbContext context) : base(context)
        {
        }
    }
}