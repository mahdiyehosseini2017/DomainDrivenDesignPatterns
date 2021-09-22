using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HSN.Framework.Infr.EF
{
    public interface IGenericReadRepository<T> where T : class
    {
        Task<T> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> ListAsync(CancellationToken cancellationToken = default);
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GraphListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
        Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
        Task<T> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    }
}
