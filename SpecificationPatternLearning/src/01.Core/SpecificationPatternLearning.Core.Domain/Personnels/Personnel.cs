using HSN.Framework.Core.Domain;
using SpecificationPatternLearning.Core.Domain.Utilities;

namespace SpecificationPatternLearning.Core.Domain.Personnels
{
    public class Personnel : IEntity<int>, IHistorical
    {
        private Personnel()
        {
        }

        public Personnel(int id, string name, string family, string personnelNumber, Status status)
        {
            Id = id;
            Name = name;
            Family = family;
            PersonnelNumber = personnelNumber;
            Status = status;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PersonnelNumber { get; private set; }
        public Status Status { get; private set; }

        
    }
}