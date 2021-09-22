using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecificationPatternLearning.Core.Domain.PersonnelEducations;

namespace SpecificationPatternLearning.Infra.Data.EfCore.SQL.PersonnelEducations.Configs
{
    public class EducationTypeConfig : IEntityTypeConfiguration<EducationType>
    {
        public void Configure(EntityTypeBuilder<EducationType> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Code).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Title).HasMaxLength(200).IsRequired();

            builder.HasData(new EducationType(1, "diplom", "Diploma")
                          , new EducationType(2, "lisans", "Bachelor")
                          , new EducationType(3, "foghe-lisance", "Masters")
                          , new EducationType(4, "doktora", "PhD"));
        }
    }
}
