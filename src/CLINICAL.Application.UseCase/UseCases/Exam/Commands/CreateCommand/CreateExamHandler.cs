using AutoMapper;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand
{
    public class CreateExamHandler : IRequestHandler<CreateExamCommand, BaseReponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseReponse<bool>> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<bool>();
            try
            {
                var exam = _mapper.Map<Entity.Exam>(request);
                var paramaters = exam.GetPropertiesWithValue();

                response.Data = await _unitOfWork.Exam.ExecAsync(SP.upsExamRegister, paramaters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_SAVE; 
                }

            }catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
