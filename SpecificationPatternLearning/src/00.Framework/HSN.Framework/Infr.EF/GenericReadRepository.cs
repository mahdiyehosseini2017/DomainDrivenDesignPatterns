using HSN.Framework.Infr.EF.Extentions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HSN.Framework.Infr.EF
{
    public class GenericReadRepository<T> : IGenericReadRepository<T> where T : class
    {
        private readonly DbContext _context;

        public GenericReadRepository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
            => await _context.Set<T>().CountAsync(cancellationToken);

        public virtual async Task<T> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
            => await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);

        public virtual async Task<IEnumerable<T>> ListAsync(CancellationToken cancellationToken = default)
            => await _context.Set<T>().ToListAsync(cancellationToken);

        public virtual async Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
            => await SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), specification).CountAsync(cancellationToken);

        public virtual async Task<IEnumerable<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
            => await SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), specification).ToListAsync(cancellationToken);

        public virtual async Task<IEnumerable<T>> GraphListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            specification.IncludePaths = _context.GetIncludePaths(typeof(T)).ToList();
            return await SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), specification).ToListAsync(cancellationToken);
        }

        public virtual async Task<T> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
            => await SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), specification).FirstOrDefaultAsync(cancellationToken);

    }
}
