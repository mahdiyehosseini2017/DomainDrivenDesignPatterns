using HSN.Framework.Core.Domain;

namespace SpecificationPatternLearning.Core.Domain.PersonnelEducations
{
    public class EducationType : IEntity<int>
    {
        private EducationType()
        {
        }

        public EducationType(int id, string code, string title)
        {
            Id = id;
            Code = code;
            Title = title;
        }

        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Title { get; private set; }
    }
}