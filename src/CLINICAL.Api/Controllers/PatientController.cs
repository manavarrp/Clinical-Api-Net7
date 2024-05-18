using CLINICAL.Application.UseCase.UseCases.Patient.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Commands.RemoveCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListPatient([FromQuery] GetAllPatientQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{patientId:int}")]
        public async Task<IActionResult> PatientById(int patientId)
        {
            var response = await _mediator.Send(new GetByIdPatientQuery() { PatientId = patientId });
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> PatientRegister([FromBody] CreatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> PatientUpdate([FromBody] UpdatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Delete/{patientId:int}")]
        public async Task<IActionResult> PatientDelete(int patientId)
        {
            var response = await _mediator.Send(new RemovePatientCommad { PatientId=patientId });
            return Ok(response);
        }
    }
}
