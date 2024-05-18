using CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.RemoveCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListExams")]
        public async Task<IActionResult> ExamList([FromQuery] GetAllExamQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);    
        }

        [HttpGet("{examId:int}")]
        public async Task<IActionResult> ExamById(int examId)
        {
            var response = await _mediator.Send(new GetExamByIdQuery() { ExamId = examId });
            return Ok(response);
        }

        [HttpPost("Regsiter")]
        public async Task<IActionResult> Examregister([FromBody] CreateExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> ExamUpdate([FromBody] UpdateExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Delete/{examId:int}")]
        public async Task<IActionResult> ExamRemove(int examId)
        {
            var response = await _mediator.Send(new RemoveExamCommand { ExamId = examId });
            return Ok(response);
        }
    }
}
