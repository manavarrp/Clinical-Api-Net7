using AutoMapper;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Commands.CreateCommand
{
    public class CreateMedicHandler : IRequestHandler<CreateMedicCommand, BaseReponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMedicHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseReponse<bool>> Handle(CreateMedicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<bool>();

            try
            {
                var medic = _mapper.Map<Entity.Medic>(request);
                var parameters = medic.GetPropertiesWithValue();

                response.Data = await _unitOfWork.Medic.ExecAsync(SP.uspMedicRegister, parameters);

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
