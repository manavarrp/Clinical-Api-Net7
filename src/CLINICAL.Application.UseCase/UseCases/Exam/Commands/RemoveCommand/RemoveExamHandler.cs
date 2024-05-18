using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.RemoveCommand
{
    internal class RemoveExamHandler : IRequestHandler<RemoveExamCommand, BaseReponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveExamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseReponse<bool>> Handle(RemoveExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<bool>();
            try
            {
                response.Data = await _unitOfWork.Exam.ExecAsync(SP.upsExamRemove, request);
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
