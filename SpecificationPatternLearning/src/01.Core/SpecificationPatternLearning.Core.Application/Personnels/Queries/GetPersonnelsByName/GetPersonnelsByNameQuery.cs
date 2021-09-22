using HSN.Framework.Core.Application;
using SpecificationPatternLearning.Core.Application.Personnels.ViewModels;
using System.Collections.Generic;

namespace SpecificationPatternLearning.Core.Application.Personnels.Queries.GetPersonnelsByName
{
    public class GetPersonnelsByNameQuery : IQuery<IEnumerable<PersonnelViewModel>>
    {
        public GetPersonnelsByNameQuery(string name)
        {
            this.name = name;
        }

        public string name { get; private set; }
    }
}
