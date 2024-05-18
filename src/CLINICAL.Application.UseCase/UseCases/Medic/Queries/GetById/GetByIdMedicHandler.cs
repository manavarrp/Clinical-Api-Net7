using AutoMapper;
using CLINICAL.Application.Dtos.Medic.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetById
{
    internal class GetByIdMedicHandler : IRequestHandler<GetByIdMedicQuery, BaseReponse<GetMedicByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdMedicHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseReponse<GetMedicByIdResponseDto>> Handle(GetByIdMedicQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<GetMedicByIdResponseDto>();

            try
            {
                var medic = await _unitOfWork.Medic.GetByIdAsync(SP.uspMedicById, request);
                if (medic is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetMedicByIdResponseDto>(medic);
                response.Message = GlobalMessages.MESSAGE_QUERY;

            }
            catch (Exception ex)
            {
                response.Message =ex.Message;
            }
            return response;
           
        }

    }
}
