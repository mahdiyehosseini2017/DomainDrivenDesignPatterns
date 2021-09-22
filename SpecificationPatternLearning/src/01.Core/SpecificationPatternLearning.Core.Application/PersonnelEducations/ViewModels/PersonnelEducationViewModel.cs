using SpecificationPatternLearning.Core.Domain.PersonnelEducations;
using SpecificationPatternLearning.Core.Domain.Personnels;

namespace SpecificationPatternLearning.Core.Application.PersonnelEducations.ViewModels
{
    public class PersonnelEducationViewModel
    {
        public PersonnelEducationViewModel(int id, int personnelId, string personnelName, string personnelFamily,
                                           int educationTypeId, string educationTypeTitle, string educationTypeCode,
                                           string status)
        {
            Id = id;
            PersonnelId = personnelId;
            PersonnelName = personnelName;
            PersonnelFamily = personnelFamily;
            EducationTypeId = educationTypeId;
            EducationTypeTitle = educationTypeTitle;
            EducationTypeCode = educationTypeCode;
            Status = status;
        }

        public int Id { get; private set; }
        public int PersonnelId { get; private set; }
        public string PersonnelName { get; private set; }
        public string PersonnelFamily { get; private set; }
        public int EducationTypeId { get; private set; }
        public string EducationTypeTitle { get; private set; }
        public string EducationTypeCode { get; private set; }
        public string Status { get; private set; }

       
        public static PersonnelEducationViewModel To(PersonnelEducation entity, Personnel personnel)
        {
            return new PersonnelEducationViewModel(entity.Id, entity.PersonnelId, personnel?.Name, personnel?.Family,
                                                   entity.EducationType.Id, entity.EducationType.Title,
                                                   entity.EducationType.Code, entity.Status.ToString());
        }
    }
}
