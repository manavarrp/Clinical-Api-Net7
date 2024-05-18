using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Commands.CreateCommand
{
    public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator()
        {
            RuleFor(x => x.Names)
                .NotNull().WithMessage("Esta campo no puede ser Nulo")
                .NotEmpty().WithMessage("Esta campo no puede estar vacio");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("Esta campo no puede ser Nulo")
                .NotEmpty().WithMessage("Esta campo no puede estar vacio");

            RuleFor(x => x.DocumentTypesId)
                .NotNull().WithMessage("Esta campo no puede ser Nulo")
                .NotEmpty().WithMessage("Esta campo no puede estar vacio");

            RuleFor(x => x.DocumentNumber)
                .NotNull().WithMessage("Esta campo no puede ser Nulo")
                .NotEmpty().WithMessage("Esta campo no puede estar vacio")
                .Must(BeNumeric!).WithMessage("El campo N° Documento debe contener sólo números");
        }

        private bool BeNumeric(string value)
        {
            return int.TryParse(value, out _);
        }
    }
}
