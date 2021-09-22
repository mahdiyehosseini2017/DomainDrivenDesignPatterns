using System.Threading.Tasks;

namespace HSN.Framework.Core.Application
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
