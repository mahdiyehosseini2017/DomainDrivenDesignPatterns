using HSN.Framework.EndPoints.API;
using Microsoft.AspNetCore.Mvc;
using SpecificationPatternLearning.Core.Application.PersonnelEducations.Queries.GetPersonnelEducation;
using SpecificationPatternLearning.Core.Application.PersonnelEducations.Queries.GetPersonnelEducationCountByStatus;
using SpecificationPatternLearning.Core.Application.PersonnelEducations.Queries.GetPersonnelEducationsByType;
using SpecificationPatternLearning.Core.Application.PersonnelEducations.Queries.GetValidPersonnelEducations;
using System.Threading.Tasks;

namespace SpecificationPatternLearning.EndPoints.API.PersonnelEducations.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonnelEducationsController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public PersonnelEducationsController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("counts")]
        public async Task<ActionResult> GetCountByStatus([FromQuery] int statusId)
            => Ok(await _queryDispatcher.QueryAsync(new GetPersonnelEducationCountByStatusQuery(statusId)));

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get([FromRoute] int id)
            => Ok(await _queryDispatcher.QueryAsync(new GetPersonnelEducationQuery(id)));

        [HttpGet]
        public async Task<ActionResult> GetByType([FromQuery] int typeId)
            => Ok(await _queryDispatcher.QueryAsync(new GetPersonnelEducationsByTypeQuery(typeId)));

        [HttpGet("valid")]
        public async Task<ActionResult> GetValid()
            => Ok(await _queryDispatcher.QueryAsync(new GetValidPersonnelEducationsQuery()));
    }
}
