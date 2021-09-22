using HSN.Framework.Infr.EF;
using SpecificationPatternLearning.Core.Domain.Utilities;

namespace SpecificationPatternLearning.Core.Application.Common.Specifications
{
    public class EntityCountByStatusSpecification<T> : Specification<T> where T : IHistorical
    {
        public EntityCountByStatusSpecification(Status status) : base(c => c.Status == status)
        {
        }
    }
}
