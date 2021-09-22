using HSN.Framework.Core.Application;
using SpecificationPatternLearning.Core.Application.PersonnelEducations.ViewModels;
using SpecificationPatternLearning.Core.Domain.PersonnelEducations;
using SpecificationPatternLearning.Core.Domain.Personnels;
using System.Threading.Tasks;

namespace SpecificationPatternLearning.Core.Application.PersonnelEducations.Queries.GetPersonnelEducation
{
    public class GetPersonnelEducationHandler : IQueryHandler<GetPersonnelEducationQuery, PersonnelEducationViewModel>
    {
        private readonly IPersonnelRepository _personnelRepository;
        private readonly IPersonnelEducationRepository _educationRepository;

        public GetPersonnelEducationHandler(IPersonnelRepository personnelRepository, IPersonnelEducationRepository educationRepository)
        {
            _personnelRepository = personnelRepository;
            _educationRepository = educationRepository;
        }

        public async Task<PersonnelEducationViewModel> HandleAsync(GetPersonnelEducationQuery query)
        {
            var entity = await _educationRepository.FirstOrDefaultAsync(new PersonnelEducationWithTypeSpecification(query.id));
            var personnel = await _personnelRepository.GetByIdAsync<int>(entity.PersonnelId);

            return PersonnelEducationViewModel.To(entity, personnel);
        }
    }
}
