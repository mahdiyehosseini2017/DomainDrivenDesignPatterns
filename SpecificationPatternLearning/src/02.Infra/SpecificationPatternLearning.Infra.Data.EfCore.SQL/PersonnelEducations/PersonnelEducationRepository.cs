using HSN.Framework.Infr.EF;
using SpecificationPatternLearning.Core.Domain.PersonnelEducations;

namespace SpecificationPatternLearning.Infra.Data.EfCore.SQL.PersonnelEducations
{
    public class PersonnelEducationRepository : GenericReadRepository<PersonnelEducation>, IPersonnelEducationRepository
    {
        public PersonnelEducationRepository(PersonnelDbContext context) : base(context)
        {
        }
    }
}
