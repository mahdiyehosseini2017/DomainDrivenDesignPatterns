using HSN.Framework.Infr.EF;
using SpecificationPatternLearning.Core.Domain.PersonnelEducations;

namespace SpecificationPatternLearning.Core.Application.PersonnelEducations.Queries.GetPersonnelEducationsByType
{
    public class PersonnelEducationsByTypeSpecification : Specification<PersonnelEducation>
    {
        public PersonnelEducationsByTypeSpecification(int EducationsTypeId) : base(c => c.EducationType.Id == EducationsTypeId)
        {
            AddInclude(c => c.EducationType);
        }
    }
}
