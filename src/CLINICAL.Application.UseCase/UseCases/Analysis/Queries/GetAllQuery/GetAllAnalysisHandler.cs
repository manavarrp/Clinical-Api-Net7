using AutoMapper;
using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery
{
    public class GetAllAnalysisHandler : IRequestHandler<GetAllAnalysisQuery, BasePaginationResponse<IEnumerable<GetALLAnalysisResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetALLAnalysisResponseDto>>> Handle(GetAllAnalysisQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetALLAnalysisResponseDto>>();
            try
            {
                var count = await _unitOfWork.Analysis.CountAsync(TB.Analysis);
                var analysis = await _unitOfWork.Analysis.GetAllWithPaginationAsync(SP.uspAnalysisList, request);

                if (analysis is not null) 
                { 
                    response.IsSuccess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.Data = _mapper.Map<IEnumerable<GetALLAnalysisResponseDto>>(analysis);
                    response.Message = GlobalMessages.MESSAGE_QUERY;
                }


            }catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }
    }
}
