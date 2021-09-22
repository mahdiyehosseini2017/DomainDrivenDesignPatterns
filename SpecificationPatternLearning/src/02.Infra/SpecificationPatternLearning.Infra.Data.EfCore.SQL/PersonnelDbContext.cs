using Microsoft.EntityFrameworkCore;
using SpecificationPatternLearning.Core.Domain.Personnels;
using SpecificationPatternLearning.Core.Domain.PersonnelEducations;

namespace SpecificationPatternLearning.Infra.Data.EfCore.SQL
{
    public class PersonnelDbContext : DbContext
    {
        public PersonnelDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<PersonnelEducation> PersonnelEducations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}