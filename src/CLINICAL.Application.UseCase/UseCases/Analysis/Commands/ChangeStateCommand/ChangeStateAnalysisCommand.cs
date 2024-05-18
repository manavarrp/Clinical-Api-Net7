﻿using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand
{
    public class ChangeStateAnalysisCommand : IRequest<BaseReponse<bool>>
    {
        public int AnalysisId { get; set; }
        public int State { get; set; }
    }
}
