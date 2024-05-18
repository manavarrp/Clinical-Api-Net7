using CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeControlController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TakeControlController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TakeExamList([FromQuery] GetAllTakeExamQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{takeExamId:int}")]
        public async Task<IActionResult> TakeExamById(int takeExamId)
        {
            var response = await _mediator.Send(new  GetByIdTakeExamQuery { TakeExamId = takeExamId });
            return Ok(response);
        }
    }
}
