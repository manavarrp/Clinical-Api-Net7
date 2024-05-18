using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Commands.RemoveCommand
{
    public class RemovePatientHandler : IRequestHandler<RemovePatientCommad, BaseReponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemovePatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseReponse<bool>> Handle(RemovePatientCommad request, CancellationToken cancellationToken)
        {
            var response  = new BaseReponse<bool>();

            try 
            {
                response.Data = await _unitOfWork.Patient.ExecAsync(SP.uspPatientRemove, request);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_DELETE;
                }


            } catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
