using HSN.Framework.Core.Application;
using System.Threading.Tasks;

namespace HSN.Framework.EndPoints.API
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
