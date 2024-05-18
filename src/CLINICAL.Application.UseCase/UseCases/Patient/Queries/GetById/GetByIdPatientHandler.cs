using AutoMapper;
using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Domain.Entities;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetById
{
    public class GetByIdPatientHandler : IRequestHandler<GetByIdPatientQuery, BaseReponse<GetPatientByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdPatientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseReponse<GetPatientByIdResponseDto>> Handle(GetByIdPatientQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<GetPatientByIdResponseDto>();

            try
            {
                
                var patient = await _unitOfWork.Patient.GetByIdAsync(SP.uspPatientById, new { request.PatientId});

                if (patient is null) 
                { 
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetPatientByIdResponseDto>(patient);
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
