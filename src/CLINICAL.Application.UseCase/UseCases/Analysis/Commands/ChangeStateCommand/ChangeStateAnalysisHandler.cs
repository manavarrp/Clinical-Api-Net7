using AutoMapper;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand
{
    public class ChangeStateAnalysisHandler : IRequestHandler<ChangeStateAnalysisCommand, BaseReponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeStateAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseReponse<bool>> Handle(ChangeStateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                var parameters = analysis.GetPropertiesWithValue();
                response.Data = await _unitOfWork.Analysis.ExecAsync(SP.uspAnalysisChangeState, parameters);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se actualizó correctamente";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
