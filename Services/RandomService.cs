using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class RandomService
	{
		int seed;
        TestDbContext _ctx;
		public RandomService(TestDbContext ctx)
        {
            seed = Guid.NewGuid().GetHashCode();
            _ctx = ctx;
        }
        public async Task<int> GetRandom()
		{
            var number = new Random(seed).Next(100);

            var existeRandonNumber = await _ctx.Numbers.FirstOrDefaultAsync(n => n.Number == number);

            if (existeRandonNumber != null)
                return number;

            _ctx.Numbers.Add(new RandomNumber() { Number = number });
            _ctx.SaveChanges();
            return number;
		}

	}
}
