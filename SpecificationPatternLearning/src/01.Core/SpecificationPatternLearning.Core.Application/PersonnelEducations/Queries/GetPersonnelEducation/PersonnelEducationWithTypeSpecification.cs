using HSN.Framework.Infr.EF;
using SpecificationPatternLearning.Core.Domain.PersonnelEducations;

namespace SpecificationPatternLearning.Core.Application.PersonnelEducations.Queries.GetPersonnelEducation
{
    public class PersonnelEducationWithTypeSpecification : Specification<PersonnelEducation>
    {
        public PersonnelEducationWithTypeSpecification(int personnelEducationId) : base(c => c.Id == personnelEducationId)
        {
            AddInclude(c => c.EducationType);
        }
    }
}
