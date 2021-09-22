using HSN.Framework.Core.Application;
using SpecificationPatternLearning.Core.Application.PersonnelEducations.ViewModels;

namespace SpecificationPatternLearning.Core.Application.PersonnelEducations.Queries.GetPersonnelEducation
{
    public class GetPersonnelEducationQuery : IQuery<PersonnelEducationViewModel>
    {
        public GetPersonnelEducationQuery(int id)
        {
            this.id = id;
        }

        public int id { get; private set; }
    }
}
