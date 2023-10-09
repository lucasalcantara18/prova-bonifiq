using Infrastructure.DataAccess.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using ProvaPub.Interfaces;
using ProvaPub.Repository;
using System;

namespace ProvaPub.Tests
{
    public class StandardFixture
    {
        private readonly IServiceCollection _services;

        public TestDbContext Context { get; }

        public Mock<IProductRepository> ProductRepositoryFake { get; }
        public Mock<ICustomerRepository> CustomerRepositoryFake { get; }
        public Mock<IOrdersRepository> OrdersRepositoryFake { get; }
        public IServiceProvider ServiceProvider { get; }

        public StandardFixture()
        {

            _services = new ServiceCollection()
                .AddLogging();

            var provider = _services.BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<TestDbContext>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase("database-test");

            Context = new TestDbContext(builder.Options);

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

        public ILogger<T> GetLogger<T>() => ServiceProvider.GetRequiredService<ILogger<T>>();
    }
}