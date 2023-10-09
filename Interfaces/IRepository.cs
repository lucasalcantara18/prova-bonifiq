using ProvaPub.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ProvaPub.Interfaces
{
    public interface IRepository<TEntity> : IRepositoryBase where TEntity : class
    {
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<Pagination<TEntity>> ToListAsyncPaginated(int pageNumber, CancellationToken cancellationToken = default);

        Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default);
    }
}