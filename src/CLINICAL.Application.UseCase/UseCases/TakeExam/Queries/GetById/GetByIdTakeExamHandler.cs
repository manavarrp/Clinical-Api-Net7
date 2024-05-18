using AutoMapper;
using CLINICAL.Application.Dtos.TakeExam.response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetById
{
    public class GetByIdTakeExamHandler : IRequestHandler<GetByIdTakeExamQuery, BaseReponse<GetTakeExamByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdTakeExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseReponse<GetTakeExamByIdResponseDto>> Handle(GetByIdTakeExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<GetTakeExamByIdResponseDto>();
            try
            {
                var takeExam = await _unitOfWork.TakeExam.TakeExamById(request.TakeExamId);
                takeExam.TakeExamDetails = await _unitOfWork.TakeExam.TakeExamDetailByTakeExamId(request.TakeExamId);

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetTakeExamByIdResponseDto>(takeExam);
                response.Message = GlobalMessages.MESSAGE_QUERY;


            }catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
