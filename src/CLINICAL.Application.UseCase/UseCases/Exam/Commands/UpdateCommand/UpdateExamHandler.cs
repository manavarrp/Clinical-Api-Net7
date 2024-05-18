using AutoMapper;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.UpdateCommand
{
    public class UpdateExamHandler : IRequestHandler<UpdateExamCommand, BaseReponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseReponse<bool>> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<bool>();
            try
            {
                var exam = _mapper.Map<Entity.Exam>(request);
                var paramaters = exam.GetPropertiesWithValue();

                response.Data = await _unitOfWork.Exam.ExecAsync(SP.upsExamUpdate, paramaters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_UPDATE;
                }

            }catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
