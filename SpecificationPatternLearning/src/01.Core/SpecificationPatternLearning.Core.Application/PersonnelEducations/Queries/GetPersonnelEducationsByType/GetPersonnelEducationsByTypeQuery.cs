using HSN.Framework.Core.Application;
using SpecificationPatternLearning.Core.Application.PersonnelEducations.ViewModels;
using System.Collections.Generic;

namespace SpecificationPatternLearning.Core.Application.PersonnelEducations.Queries.GetPersonnelEducationsByType
{
   public class GetPersonnelEducationsByTypeQuery : IQuery<IEnumerable<PersonnelEducationViewModel>>
    {
        public GetPersonnelEducationsByTypeQuery(int typeId)
        {
            TypeId = typeId;
        }

        public int TypeId { get; private set; }
    }
}
