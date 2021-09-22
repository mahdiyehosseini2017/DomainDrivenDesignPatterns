using HSN.Framework.Infr.EF;
using Microsoft.EntityFrameworkCore;
using SpecificationPatternLearning.Core.Domain.Personnels;

namespace SpecificationPatternLearning.Infra.Data.EfCore.SQL.Personnels
{
    public class PersonnelRepository : GenericReadRepository<Personnel>, IPersonnelRepository
    {
        private readonly PersonnelDbContext _context;
        public PersonnelRepository(DbContext _context) : base(_context)
        {
        }

        
    }
}
