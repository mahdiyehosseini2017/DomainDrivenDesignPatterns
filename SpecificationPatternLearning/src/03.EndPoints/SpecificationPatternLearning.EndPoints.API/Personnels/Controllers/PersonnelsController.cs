using HSN.Framework.EndPoints.API;
using Microsoft.AspNetCore.Mvc;
using SpecificationPatternLearning.Core.Application.Personnels.Queries.GetPersonnelCountByStatus;
using SpecificationPatternLearning.Core.Application.Personnels.Queries.GetPersonnels;
using SpecificationPatternLearning.Core.Application.Personnels.Queries.GetPersonnelsByName;
using SpecificationPatternLearning.Core.Application.Personnels.Queries.GetValidPersonnels;
using System.Threading.Tasks;

namespace SpecificationPatternLearning.EndPoints.API.Personnels.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonnelsController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public PersonnelsController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("counts")]
        public async Task<ActionResult> GetCountByStatus([FromQuery] int statusId) 
            => Ok(await _queryDispatcher.QueryAsync(new GetPersonnelCountByStatusQuery(statusId)));

        [HttpGet]
        public async Task<ActionResult> Get() 
            => Ok(await _queryDispatcher.QueryAsync(new GetPersonnelsQuery()));

        [HttpGet("{name}")]
        public async Task<ActionResult> GetByName([FromRoute] string name) 
            => Ok(await _queryDispatcher.QueryAsync(new GetPersonnelsByNameQuery(name)));

        [HttpGet("valid")]
        public async Task<ActionResult> GetValid() 
            => Ok(await _queryDispatcher.QueryAsync(new GetValidPersonnelsQuery()));
    }
}
