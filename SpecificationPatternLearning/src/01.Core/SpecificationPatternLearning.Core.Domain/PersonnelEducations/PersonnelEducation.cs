using HSN.Framework.Core.Domain;
using SpecificationPatternLearning.Core.Domain.Utilities;

namespace SpecificationPatternLearning.Core.Domain.PersonnelEducations
{
    public class PersonnelEducation : IEntity<int>, IHistorical
    {
        private PersonnelEducation()
        {
        }

        public PersonnelEducation(int id, int personnelId, EducationType educationType, Status status)
        {
            Id = id;
            PersonnelId = personnelId;
            EducationType = educationType;
            Status = status;
        }

        public int Id { get; private set; }
        public int PersonnelId { get; private set; }
        public EducationType EducationType { get; private set; }
        public Status Status { get; private set; }
    }
}