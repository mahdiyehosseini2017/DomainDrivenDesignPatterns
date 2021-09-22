using HSN.Framework.Core.Application;
using SpecificationPatternLearning.Core.Application.Personnels.ViewModels;
using SpecificationPatternLearning.Core.Domain.Personnels;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace SpecificationPatternLearning.Core.Application.Personnels.Queries.GetPersonnels
{
    public class GetPersonnelsQueryHandler : IQueryHandler<GetPersonnelsQuery, IEnumerable<PersonnelViewModel>>
    {
        private readonly IPersonnelRepository _personnelRepository;

        public GetPersonnelsQueryHandler(IPersonnelRepository personnelRepository)
        {
            _personnelRepository = personnelRepository;
        }

        public async Task<IEnumerable<PersonnelViewModel>> HandleAsync(GetPersonnelsQuery query)
        {
            var entities = await _personnelRepository.ListAsync();
            return entities.Select(c => (PersonnelViewModel)c);
        }
    }
}
