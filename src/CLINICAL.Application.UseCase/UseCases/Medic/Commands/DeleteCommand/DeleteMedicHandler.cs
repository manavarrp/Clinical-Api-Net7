﻿using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Commands.DeleteCommand
{
    public class DeleteMedicHandler : IRequestHandler<DeleteMedicCommand, BaseReponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMedicHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseReponse<bool>> Handle(DeleteMedicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<bool>();
            try
            {
                response.Data = await _unitOfWork.Medic.ExecAsync(SP.uspMedicRemove, request);
                if (!response.Data)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                }

                response.IsSuccess = true;
                response.Message = GlobalMessages.MESSAGE_DELETE;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
