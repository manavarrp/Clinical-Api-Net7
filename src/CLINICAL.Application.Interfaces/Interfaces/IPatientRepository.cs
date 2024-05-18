﻿using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interfaces.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatients(string storedProcedure);
    }
}
