using SpecificationPatternLearning.Core.Domain.Personnels;

namespace SpecificationPatternLearning.Core.Application.Personnels.ViewModels
{
  public  class PersonnelViewModel
    {
        public PersonnelViewModel(int id, string name, string family, string personnelNumber, string status)
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
        public string Status { get; private set; }

        public static implicit operator PersonnelViewModel(Personnel entity) 
            => new PersonnelViewModel(entity.Id, entity.Name, entity.Family, entity.PersonnelNumber, entity.Status.ToString());
    }
}
