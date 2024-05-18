using AutoMapper;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisHandler : IRequestHandler<CreateAnalysisCommand, BaseReponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseReponse<bool>> Handle(CreateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                var parameters = analysis.GetPropertiesWithValue();

                
                response.Data = await _unitOfWork.Analysis.ExecAsync(SP.uspAnalysisRegister, parameters);
                if(response.Data) 
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_SAVE;
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
