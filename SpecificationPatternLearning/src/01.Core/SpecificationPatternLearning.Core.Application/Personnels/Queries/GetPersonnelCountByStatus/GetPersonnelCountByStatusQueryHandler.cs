using HSN.Framework.Core.Application;
using SpecificationPatternLearning.Core.Application.Common.Specifications;
using SpecificationPatternLearning.Core.Domain.Personnels;
using SpecificationPatternLearning.Core.Domain.Utilities;
using System.Threading.Tasks;

namespace SpecificationPatternLearning.Core.Application.Personnels.Queries.GetPersonnelCountByStatus
{
    public class GetPersonnelCountByStatusQueryHandler : IQueryHandler<GetPersonnelCountByStatusQuery, int>
    {
        private readonly IPersonnelRepository _personnelRepository;

        public GetPersonnelCountByStatusQueryHandler(IPersonnelRepository personnelRepository)
        {
            _personnelRepository = personnelRepository;
        }

        public async Task<int> HandleAsync(GetPersonnelCountByStatusQuery query)
        {
            return await _personnelRepository.CountAsync(new EntityCountByStatusSpecification<Personnel>((Status) query.StatusId));
        }
    }
}
