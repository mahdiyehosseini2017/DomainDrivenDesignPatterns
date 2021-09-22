using HSN.Framework.Core.Application;
using SpecificationPatternLearning.Core.Application.Personnels.ViewModels;
using SpecificationPatternLearning.Core.Domain.Personnels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationPatternLearning.Core.Application.Personnels.Queries.GetPersonnelsByName
{
    public class GetPersonnelsByNameHandler : IQueryHandler<GetPersonnelsByNameQuery, IEnumerable<PersonnelViewModel>>
    {
        private readonly IPersonnelRepository _personnelRepository;

        public GetPersonnelsByNameHandler(IPersonnelRepository personnelRepository)
        {
            _personnelRepository = personnelRepository;
        }

        public async Task<IEnumerable<PersonnelViewModel>> HandleAsync(GetPersonnelsByNameQuery query)
        {
            var entities = await _personnelRepository.ListAsync(new PersonnelNameFilterSpecification(query.name));
            return entities.Select(c => (PersonnelViewModel)c);
        }
    }
}

