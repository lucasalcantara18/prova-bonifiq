using Microsoft.EntityFrameworkCore;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using System.Linq.Expressions;

namespace ProvaPub.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly TestDbContext _context;

        protected BaseRepository(TestDbContext context)
        {
            _context = context;
        }

        public virtual Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return _context.Set<TEntity>().ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Erro ao listar entidades", e);
            }
        }

        public Task<Pagination<TEntity>> ToListAsyncPaginated(int pageNumber, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _context.Set<TEntity>().Skip((pageNumber - 1) * 10).Take(10).ToListAsync(cancellationToken);
                return Task.FromResult(new Pagination<TEntity>(10, result.Result));
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Erro ao listar entidades", e);
            }
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return _context.Set<TEntity>().CountAsync(predicate, cancellationToken);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Erro ao contar entidades", e);
            }
        }

        public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
#pragma warning disable CS8619 // A anulabilidade de tipos de referência no valor não corresponde ao tipo de destino.
                return _context.Set<TEntity>().FirstOrDefaultAsync(predicate, cancellationToken);
#pragma warning restore CS8619 // A anulabilidade de tipos de referência no valor não corresponde ao tipo de destino.
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Erro ao encontrar entidade", e);
            }
        }
    }
}