using AutoMapper;
using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Domain.Entities;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetAllQuery
{
    internal class GetAllPatientHandler : IRequestHandler<GetAllPatientQuery, BasePaginationResponse<IEnumerable<GetAllPatientResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPatientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllPatientResponseDto>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllPatientResponseDto>>();
            try
            {
                var count = await _unitOfWork.Analysis.CountAsync(TB.Patients);
                var patients = await _unitOfWork.Patient.GetAllWithPaginationAsync(SP.uspPatienList, request);
                if(patients is not null)
                {
                    response.IsSuccess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.Data = _mapper.Map<IEnumerable<GetAllPatientResponseDto>>(patients);
                    response.Message = GlobalMessages.MESSAGE_QUERY;
                }

            }catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }
    }
}
