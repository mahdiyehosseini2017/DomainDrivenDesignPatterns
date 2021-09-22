using HSN.Framework.Infr.EF;
using SpecificationPatternLearning.Core.Domain.Utilities;

namespace SpecificationPatternLearning.Core.Application.Common.Specifications
{
    public class ValidEntitiesSpecification<T> : Specification<T> where T : IHistorical
    {
        public ValidEntitiesSpecification() : base(x => x.Status != Status.Rejected)
        {

        }
    }
}
