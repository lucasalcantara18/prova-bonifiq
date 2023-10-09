using ProvaPub.Models;
using System.Collections.Generic;

namespace ProvaPub.Interfaces
{
    public interface ICustomerService
    {
        public Task<Pagination<Customer>> ListCustomers(int page);

        public Task<bool> CanPurchase(int customerId, decimal purchaseValue);
    }
}