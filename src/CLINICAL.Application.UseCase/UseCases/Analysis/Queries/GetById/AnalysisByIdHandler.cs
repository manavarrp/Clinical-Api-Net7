using AutoMapper;
using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetById
{
    public class AnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseReponse<GetAnalysisByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnalysisByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseReponse<GetAnalysisByIdResponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<GetAnalysisByIdResponseDto>();

            try
            {
                var analysis = await _unitOfWork.Analysis.GetByIdAsync(SP.uspAnalysisById, new {request.AnalysisId});
                if (analysis is null) 
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetAnalysisByIdResponseDto>(analysis);
                response.Message = GlobalMessages.MESSAGE_QUERY;

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
