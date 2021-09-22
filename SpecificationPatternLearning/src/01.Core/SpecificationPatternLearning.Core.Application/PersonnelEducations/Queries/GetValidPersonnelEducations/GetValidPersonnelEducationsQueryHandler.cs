using HSN.Framework.Core.Application;
using SpecificationPatternLearning.Core.Application.Common.Specifications;
using SpecificationPatternLearning.Core.Application.PersonnelEducations.ViewModels;
using SpecificationPatternLearning.Core.Domain.PersonnelEducations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationPatternLearning.Core.Application.PersonnelEducations.Queries.GetValidPersonnelEducations
{
    public class GetValidPersonnelEducationsQueryHandler : IQueryHandler<GetValidPersonnelEducationsQuery, IEnumerable<PersonnelEducationViewModel>>
    {
        private readonly IPersonnelEducationRepository _personnelEducationRepository;

        public GetValidPersonnelEducationsQueryHandler(IPersonnelEducationRepository personnelEducationRepository)
        {
            _personnelEducationRepository = personnelEducationRepository;
        }

        public async Task<IEnumerable<PersonnelEducationViewModel>> HandleAsync(GetValidPersonnelEducationsQuery query)
        {
            var entities = await _personnelEducationRepository.GraphListAsync(new ValidEntitiesSpecification<PersonnelEducation>());
            return entities.Select(c => PersonnelEducationViewModel.To(c, null));
        }
    }
}
