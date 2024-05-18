using AutoMapper;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.RemoveCommand
{
    public class RemoveAnalysisHandler : IRequestHandler<RemoveAnalysisCommand, BaseReponse<bool>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public RemoveAnalysisHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseReponse<bool>> Handle(RemoveAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<bool>();

            try
            {
                response.Data = await _unitOfWork.Analysis.ExecAsync(SP.uspAnalysisRemove, request);

                if(response.Data) 
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_DELETE;
                }

            }catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
