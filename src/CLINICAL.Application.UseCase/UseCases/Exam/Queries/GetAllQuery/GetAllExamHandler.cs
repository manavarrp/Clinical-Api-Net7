using AutoMapper;
using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.Dtos.Medic.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Domain.Entities;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetAllQuery
{
    public class GetAllExamHandler : IRequestHandler<GetAllExamQuery, BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>> Handle(GetAllExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>();

            try
            {
                var count = await _unitOfWork.Analysis.CountAsync(TB.Exams);
                var exams = await _unitOfWork.Exam.GetAllWithPaginationAsync(SP.uspExamList, request);
                if (exams is not null)
                {
                    response.IsSuccess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.Data = response.Data = _mapper.Map<IEnumerable<GetAllExamResponseDto>>(exams);
                    response.Message = GlobalMessages.MESSAGE_QUERY;
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
