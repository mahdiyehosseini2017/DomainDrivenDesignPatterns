using HSN.Framework.Core.Application;

namespace SpecificationPatternLearning.Core.Application.Personnels.Queries.GetPersonnelCountByStatus
{
    public class GetPersonnelCountByStatusQuery : IQuery<int>
    {
        public GetPersonnelCountByStatusQuery(int statusId)
        {
            StatusId = statusId;
        }

        public int StatusId { get; private set; }
    }
}
