using HSN.Framework.Core.Application;

namespace SpecificationPatternLearning.Core.Application.PersonnelEducations.Queries.GetPersonnelEducationCountByStatus
{
    public class GetPersonnelEducationCountByStatusQuery : IQuery<int>
    {
        public GetPersonnelEducationCountByStatusQuery(int statusId)
        {
            StatusId = statusId;
        }

        public int StatusId { get; private set; }
    }
}
