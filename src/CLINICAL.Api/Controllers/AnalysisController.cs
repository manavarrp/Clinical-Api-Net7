using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.EditCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.RemoveCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListAnalysis([FromQuery] GetAllAnalysisQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{analysisId:int}")]
        public async Task<IActionResult> GetAnalysisById(int analysisId)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery() { AnalysisId = analysisId});
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAnalysis([FromBody] CreateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditAnalysis([FromBody] EditAnalysisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{analysisId:int}")]
        public async Task<IActionResult> RemoveAnalysis(int analysisId)
        {
            var response = await _mediator.Send(new RemoveAnalysisCommand() { AnalysisId = analysisId });
            return Ok(response);
        }

        [HttpPut("Edit/ChangeState")]
        public async Task<IActionResult> EditStateAnalysis([FromBody] ChangeStateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
