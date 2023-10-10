using Moq;
using ProvaPub.Interfaces;

namespace ProvaPub.Tests
{
    public class StandardFixture
    {
        private readonly IServiceCollection _services;

        public Mock<IProductRepository> ProductRepositoryFake { get; }
        public Mock<ICustomerRepository> CustomerRepositoryFake { get; }
        public Mock<IOrdersRepository> OrdersRepositoryFake { get; }
        public IServiceProvider ServiceProvider { get; }

        public StandardFixture()
        {
            _services = new ServiceCollection();

            ServiceProvider = _services.BuildServiceProvider();

            ProductRepositoryFake = new Mock<IProductRepository>();
            CustomerRepositoryFake = new Mock<ICustomerRepository>();
            OrdersRepositoryFake = new Mock<IOrdersRepository>();
        }

        public void ClearSetup()
        {
            ProductRepositoryFake.Invocations.Clear();
            CustomerRepositoryFake.Invocations.Clear();
            OrdersRepositoryFake.Invocations.Clear();
        }
    }
}