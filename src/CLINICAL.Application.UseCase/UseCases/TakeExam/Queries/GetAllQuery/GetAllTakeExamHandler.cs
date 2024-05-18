using AutoMapper;
using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetAllQuery
{
    internal class GetAllTakeExamHandler : IRequestHandler<GetAllTakeExamQuery, BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTakeExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>> Handle(GetAllTakeExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>();
            try
            {
                var count = await _unitOfWork.TakeExam.CountAsync(TB.TakeExam);
                var takeExams = await _unitOfWork.TakeExam.GetAllTakeExamList(SP.upsTakeExamList, request);

                if(takeExams is not null)
                {
                    response.IsSuccess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.Data = _mapper.Map<IEnumerable<GetAllExamResponseDto>>(takeExams);
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
