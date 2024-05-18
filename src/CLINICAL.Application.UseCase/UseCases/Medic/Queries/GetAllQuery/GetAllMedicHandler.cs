using AutoMapper;
using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.Dtos.Medic.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Domain.Entities;
using CLINICAL.Utilities.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetAllQuery
{
    internal class GetAllMedicHandler : IRequestHandler<GetAllMedicQuery, BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllMedicHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>> Handle(GetAllMedicQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>();

            try
            {
                var count = await _unitOfWork.Analysis.CountAsync(TB.Medics);
                var medics = await _unitOfWork.Medic.GetAllWithPaginationAsync(SP.uspMedicList, request);

                if(response.Data is null) 
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                }

                response.IsSuccess = true;
                response.PageNumber = request.PageNumber;
                response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                response.TotalCount = count;
                response.Data = _mapper.Map<IEnumerable<GetAllMedicResponseDto>>(medics);
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
