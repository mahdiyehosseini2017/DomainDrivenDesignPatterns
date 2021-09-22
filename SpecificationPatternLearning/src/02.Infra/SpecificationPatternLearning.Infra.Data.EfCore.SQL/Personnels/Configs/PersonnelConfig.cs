using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecificationPatternLearning.Core.Domain.Personnels;

namespace SpecificationPatternLearning.Infra.Data.EfCore.SQL.Personnels.Configs
{
    public class PersonnelConfig : IEntityTypeConfiguration<Personnel>
    {
        public void Configure(EntityTypeBuilder<Personnel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(200).IsRequired();
            builder.Property(c => c.Family).HasMaxLength(200).IsRequired();
            builder.Property(c => c.PersonnelNumber).HasMaxLength(10).IsFixedLength().IsRequired();
        }
    }
}
