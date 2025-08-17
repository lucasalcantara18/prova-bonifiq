namespace ProvaPub.Interfaces
{
    public interface IPaymentMethod
    {
        string PaymentMethod { get; }
        bool ProcessPayment(decimal paymentValue, int customerId);
    }
}
