using ProvaPub.Models;
using System.Collections.Generic;

namespace ProvaPub.Interfaces
{
    public abstract class PaymentService
    {
        public decimal PaymentValue { get; set; }
        public int CustomerId { get; set; }

        public PaymentService(decimal paymentValue, int customerId)
        {
            this.PaymentValue = paymentValue;
            this.CustomerId = customerId;
        }

        public abstract Task<Order> PayAsync();
    }
}