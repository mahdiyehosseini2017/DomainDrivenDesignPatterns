using HSN.Framework.Core.Application;
using SpecificationPatternLearning.Core.Application.PersonnelEducations.ViewModels;
using SpecificationPatternLearning.Core.Domain.PersonnelEducations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationPatternLearning.Core.Application.PersonnelEducations.Queries.GetPersonnelEducationsByType
{
    public class GetPersonnelEducationsByTypeHandler : IQueryHandler<GetPersonnelEducationsByTypeQuery, IEnumerable<PersonnelEducationViewModel>>
    {
        private readonly IPersonnelEducationRepository _personnelEducationRepository;

        public GetPersonnelEducationsByTypeHandler(IPersonnelEducationRepository personnelEducationRepository)
        {
            _personnelEducationRepository = personnelEducationRepository;
        }

        public async Task<IEnumerable<PersonnelEducationViewModel>> HandleAsync(GetPersonnelEducationsByTypeQuery query)
        {
            var entities = await _personnelEducationRepository.ListAsync(new PersonnelEducationsByTypeSpecification(query.TypeId));
            return entities.Select(c => PersonnelEducationViewModel.To(c, null));
        }
    }
}
