using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.EditCommand
{
    public class EditAnalysisValidator : AbstractValidator<EditAnalysisCommand>
    {
        public EditAnalysisValidator()
        {
            RuleFor(x =>x.Name)
                .NotNull().WithMessage("El campo nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo nombre no puede ser vacio");
        }
    }
}
