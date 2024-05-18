using AutoMapper;
using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetById
{
    public class GetExamByIdHandler : IRequestHandler<GetExamByIdQuery, BaseReponse<GetExamByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetExamByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseReponse<GetExamByIdResponseDto>> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<GetExamByIdResponseDto>();

            try
            {
                var exam = await _unitOfWork.Exam.GetByIdAsync(SP.uspExamById, new { request.ExamId });
                if (exam is null) 
                { 
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetExamByIdResponseDto>(exam);
                response.Message = GlobalMessages.MESSAGE_QUERY;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
