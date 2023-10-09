using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace Infrastructure.DataAccess.Repositories.Entities
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(TestDbContext context) : base(context)
        {
        }
    }
}