using AutoMapper;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Commands.UpdateCommand
{
    public class UpdateMedicHandler : IRequestHandler<UpdateMedicCommand, BaseReponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMedicHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseReponse<bool>> Handle(UpdateMedicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<bool>();
            try
            {
                var medicy = _mapper.Map<Entity.Medic>(request);
                var parameters = medicy.GetPropertiesWithValue();

                response.Data = await _unitOfWork.Medic.ExecAsync(SP.uspMedicUpdate, parameters);
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
