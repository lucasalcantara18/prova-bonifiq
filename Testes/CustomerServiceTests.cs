using Bogus;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using Xunit;
using Xunit.Sdk;

namespace ProvaPub.Testes
{
    public class CustomerServiceTests
    {
        private readonly TestDbContext _ctx;
        private readonly CustomerService _service;

        public CustomerServiceTests()
        {
            _ctx = Create();
            _service = new CustomerService(_ctx);
        }

        public static TestDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestDb_" + Guid.NewGuid() + ";Trusted_Connection=True;")
                .Options;

            var context = new TestDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }


        [Fact]
        public async Task CamPurchase_CustomerId0_error()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _service.CanPurchase(0, 10M));
        }

        [Fact]
        public async Task CamPurchase_PurchaseValue0_error()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _service.CanPurchase(1, 0M));
        }


        [Fact]
        public async Task CamPurchase_FindAsyncReturnsNull_error()
        {
            //Act & Assert
            var throws = await Assert.ThrowsAsync<InvalidOperationException>(async () => await _service.CanPurchase(31, 10M));

            Assert.Equal("Customer Id 31 does not exists", throws.Message);
        }

        [Fact]
        public async Task CamPurchase_OrderCountMoreThan0_error()
        {
            var result = await _service.CanPurchase(11, 10M);

            Assert.False(result);
        }


        [Fact]
        public async Task CamPurchase_FirstPurchaseMoreThan100_error()
        {
            var result = await _service.CanPurchase(12, 1000M);

            Assert.False(result);
        }

        [Fact]
        public async Task CamPurchase_PurchaseOutsideComercialHours_error()
        {
            //Teste para rodar fora do horario comercial
            if (DateTime.UtcNow.Hour < 8 || DateTime.UtcNow.Hour > 18 || DateTime.UtcNow.DayOfWeek == DayOfWeek.Saturday || DateTime.UtcNow.DayOfWeek == DayOfWeek.Sunday)
            {
                var result = await _service.CanPurchase(12, 10M);
                Assert.False(result);
            }
        }

        [Fact]
        public async Task CamPurchase__success()
        {
            //teste para rodar dentro do horario comercial
            if (DateTime.UtcNow.Hour >= 8 && DateTime.UtcNow.Hour <= 18 && DateTime.UtcNow.DayOfWeek != DayOfWeek.Saturday && DateTime.UtcNow.DayOfWeek != DayOfWeek.Sunday)
            {
                var result = await _service.CanPurchase(1, 90M);
                Assert.True(result);
            }
        }
    }
}
