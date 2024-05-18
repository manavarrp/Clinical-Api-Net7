using AutoMapper;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Commands.UpdateCommand
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, BaseReponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePatientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseReponse<bool>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<bool>();
            try
            {
                var patient = _mapper.Map<Entity.Patient>(request);
                var parameters = patient.GetPropertiesWithValue();

                response.Data = await _unitOfWork.Patient.ExecAsync(SP.uspPatientUpdate, parameters);
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
