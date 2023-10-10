using Moq;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Services;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ProvaPub.Tests
{
    public class CustomerServiceTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;
        private readonly CustomerService _useCase;

        public CustomerServiceTests(StandardFixture fixture)
        {
            _fixture = fixture;
            _useCase = new(_fixture.CustomerRepositoryFake.Object,
                _fixture.OrdersRepositoryFake.Object);
        }

        [Fact]
        public async Task CamPurchase_CustomerId0_error()
        {
            var customerId = 0;
            var purchaseValue = 10M;

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _useCase.CanPurchase(customerId, purchaseValue));
        }

        [Fact]
        public async Task CamPurchase_PurchaseValue0_error()
        {
            var customerId = 1;
            var purchaseValue = 0M;

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _useCase.CanPurchase(customerId, purchaseValue));
        }


        [Fact]
        public async Task CamPurchase_FindAsyncReturnsNull_error()
        {
            _fixture.ClearSetup();
            var customerId = 1;
            var purchaseValue = 10M;

            _fixture.CustomerRepositoryFake
                .Setup(x => x.FindAsync(customer => customer.Id == customerId, default))
                .ReturnsAsync(() => null);

            var throws = await Assert.ThrowsAsync<InvalidOperationException>(async () => await _useCase.CanPurchase(customerId, purchaseValue));

            Assert.Equal("Customer Id 1 does not exists", throws.Message);
        }

        [Fact]
        public async Task CamPurchase_OrderCountMoreThan0_error()
        {
            _fixture.ClearSetup();
            var customerId = 1;
            var purchaseValue = 10M;
            var customer = new Customer { Id = customerId, Name = "Ciclano da Silva" };
            var numberOfOrders = 1;

            _fixture.CustomerRepositoryFake
                .Setup(x => x.FindAsync(customer => customer.Id == customerId, default))
                .ReturnsAsync(customer);

            _fixture.OrdersRepositoryFake
                .Setup(x => x.CountAsync(It.IsAny<Expression<Func<Order, bool>>>(), default))
                .ReturnsAsync(numberOfOrders);

            var result = await _useCase.CanPurchase(customerId, purchaseValue);

            Assert.False(result);
        }


        [Fact]
        public async Task CamPurchase_FirstPurchaseMoreThan100_error()
        {
            _fixture.ClearSetup();
            var customerId = 1;
            var purchaseValue = 1000M;
            var customer = new Customer { Id = customerId, Name = "Ciclano da Silva" };
            var numberOfOrders = 0;

            _fixture.CustomerRepositoryFake
                .Setup(x => x.FindAsync(customer => customer.Id == customerId, default))
                .ReturnsAsync(customer);

            _fixture.OrdersRepositoryFake
                .Setup(x => x.CountAsync(It.IsAny<Expression<Func<Order, bool>>>(), default))
                .ReturnsAsync(numberOfOrders);

            _fixture.CustomerRepositoryFake
                .Setup(x => x.CountAsync(It.IsAny<Expression<Func<Customer, bool>>>(), default))
                .ReturnsAsync(numberOfOrders);

            var result = await _useCase.CanPurchase(customerId, purchaseValue);

            Assert.False(result);
        }

        [Fact]
        public async Task CamPurchase__success()
        {
            _fixture.ClearSetup();
            var customerId = 1;
            var purchaseValue = 90M;
            var customer = new Customer { Id = customerId, Name = "Ciclano da Silva" };
            var numberOfOrders = 0;

            _fixture.CustomerRepositoryFake
                .Setup(x => x.FindAsync(customer => customer.Id == customerId, default))
                .ReturnsAsync(customer);

            _fixture.OrdersRepositoryFake
                .Setup(x => x.CountAsync(It.IsAny<Expression<Func<Order, bool>>>(), default))
                .ReturnsAsync(numberOfOrders);

            _fixture.CustomerRepositoryFake
                .Setup(x => x.CountAsync(It.IsAny<Expression<Func<Customer, bool>>>(), default))
                .ReturnsAsync(numberOfOrders);

            var result = await _useCase.CanPurchase(customerId, purchaseValue);

            Assert.True(result);
        }
    }
}
