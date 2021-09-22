using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HSN.Framework.Infr.EF
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
           
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            
            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if(spec.IncludePaths.Count > 0)
            {
                query = AddIncludePaths(spec, query);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            
            return query;
        }

        private static IQueryable<TEntity> AddIncludePaths(ISpecification<TEntity> spec, IQueryable<TEntity> query)
        {
            foreach (var item in spec.IncludePaths)
            {
                query = query.Include(item);
            }

            return query;
        }
    }
}
