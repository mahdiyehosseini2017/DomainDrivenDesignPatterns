using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecificationPatternLearning.Core.Domain.PersonnelEducations;
using SpecificationPatternLearning.Core.Domain.Personnels;

namespace SpecificationPatternLearning.Infra.Data.EfCore.SQL.PersonnelEducations.Configs
{
    public class PersonnelEducationConfig : IEntityTypeConfiguration<PersonnelEducation>
    {
        public void Configure(EntityTypeBuilder<PersonnelEducation> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne<Personnel>().WithMany().HasForeignKey(c => c.PersonnelId).HasPrincipalKey(c => c.Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.EducationType).WithMany().OnDelete(DeleteBehavior.NoAction);

        }
    }
}
