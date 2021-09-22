using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HSN.Framework.Infr.EF
{
    public class Specification<T> : ISpecification<T>
    {
        public Specification()
        {
        }

        public Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public List<string> IncludePaths { get; set; } = new List<string>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddIncludePaths(IEnumerable<string> includeExpressions)
        {
            IncludePaths.AddRange(includeExpressions);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
    }
}
