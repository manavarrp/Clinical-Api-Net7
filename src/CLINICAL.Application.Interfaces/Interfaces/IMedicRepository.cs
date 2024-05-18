using CLINICAL.Application.Dtos.Medic.Response;
using CLINICAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.Interfaces.Interfaces
{
    public interface IMedicRepository : IGenericRepository<Medic>
    {
        Task<IEnumerable<GetAllMedicResponseDto>> GetAllMedicList(string storedProcedure);
    }
}
