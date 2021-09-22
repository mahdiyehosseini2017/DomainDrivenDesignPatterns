using HSN.Framework.Infr.EF;
using SpecificationPatternLearning.Core.Domain.Personnels;

namespace SpecificationPatternLearning.Core.Application.Personnels.Queries.GetPersonnelsByName
{
    public class PersonnelNameFilterSpecification : Specification<Personnel>
    {
        public PersonnelNameFilterSpecification(string name) : base(c => c.Name == name)
        {
            AddOrderBy(c => c.Family);
        }
    }
}
