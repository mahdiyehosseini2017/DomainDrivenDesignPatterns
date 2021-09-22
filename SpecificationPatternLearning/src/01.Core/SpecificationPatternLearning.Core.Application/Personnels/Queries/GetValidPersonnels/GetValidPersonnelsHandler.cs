using HSN.Framework.Core.Application;
using SpecificationPatternLearning.Core.Application.Personnels.ViewModels;
using SpecificationPatternLearning.Core.Domain.Personnels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SpecificationPatternLearning.Core.Application.Common.Specifications;

namespace SpecificationPatternLearning.Core.Application.Personnels.Queries.GetValidPersonnels
{
    public class GetValidPersonnelsHandler : IQueryHandler<GetValidPersonnelsQuery, IEnumerable<PersonnelViewModel>>
    {
        private readonly IPersonnelRepository _personnelRepository;

        public GetValidPersonnelsHandler(IPersonnelRepository personnelRepository)
        {
            _personnelRepository = personnelRepository;
        }

        public async Task<IEnumerable<PersonnelViewModel>> HandleAsync(GetValidPersonnelsQuery query)
        {
            var entities = await _personnelRepository.ListAsync(new ValidEntitiesSpecification<Personnel>());
            return entities.Select(c => (PersonnelViewModel)c);
        }
    }
}
