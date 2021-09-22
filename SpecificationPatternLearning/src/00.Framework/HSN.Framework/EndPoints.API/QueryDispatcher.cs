using HSN.Framework.Core.Application;
using System;
using System.Threading.Tasks;

namespace HSN.Framework.EndPoints.API
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {       
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _serviceProvider.GetService(handlerType);

            return await handler.HandleAsync((dynamic)query);
        }
    }
}
