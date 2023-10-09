using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace Infrastructure.DataAccess.Repositories.Entities
{
    public class OrdersRepository : BaseRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(TestDbContext context) : base(context)
        {
        }
    }
}