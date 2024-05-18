using AutoMapper;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.EditCommand
{
    public class EditAnalysisHandler : IRequestHandler<EditAnalysisCommand, BaseReponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseReponse<bool>> Handle(EditAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                var parameters = analysis.GetPropertiesWithValue();

                response.Data = await _unitOfWork.Analysis.ExecAsync(SP.uspAnalysisEdit, parameters);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_UPDATE;
                }

            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
