using CLINICAL.Application.UseCase.UseCases.Medic.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Medic.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCases.Medic.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetById;
using CLINICAL.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> MedicsList([FromQuery] GetAllMedicQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{medicId:int}")]
        public async Task<IActionResult> MedicById(int medicId)
        {
            var response = await _mediator.Send(new GetByIdMedicQuery { MedicId = medicId });
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> MedicRegister([FromBody] CreateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> MedicUpdate([FromBody] UpdateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Delete/{medicId:int}")]
        public  async Task<IActionResult> MedicDelete(int medicId)
        {
            var response = await _mediator.Send(new DeleteMedicCommand { MedicId = medicId });
            return Ok(response);
        }
    }
}
