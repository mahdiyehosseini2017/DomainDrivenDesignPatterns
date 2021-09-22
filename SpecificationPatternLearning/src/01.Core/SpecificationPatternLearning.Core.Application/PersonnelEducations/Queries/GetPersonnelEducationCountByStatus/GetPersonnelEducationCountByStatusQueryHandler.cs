using HSN.Framework.Core.Application;
using SpecificationPatternLearning.Core.Application.Common.Specifications;
using SpecificationPatternLearning.Core.Domain.PersonnelEducations;
using SpecificationPatternLearning.Core.Domain.Utilities;
using System.Threading.Tasks;

namespace SpecificationPatternLearning.Core.Application.PersonnelEducations.Queries.GetPersonnelEducationCountByStatus
{
    public class GetPersonnelEducationCountByStatusQueryHandler : IQueryHandler<GetPersonnelEducationCountByStatusQuery, int>
    {
        private readonly IPersonnelEducationRepository _personnelEducationRepository;

        public GetPersonnelEducationCountByStatusQueryHandler(IPersonnelEducationRepository personnelEducationRepository)
        {
            _personnelEducationRepository = personnelEducationRepository;
        }

        public async Task<int> HandleAsync(GetPersonnelEducationCountByStatusQuery query)
        {
            return await _personnelEducationRepository.CountAsync(new EntityCountByStatusSpecification<PersonnelEducation>((Status)query.StatusId));
        }
    }
}
