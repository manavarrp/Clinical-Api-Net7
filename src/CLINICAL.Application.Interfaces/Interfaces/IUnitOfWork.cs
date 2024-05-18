using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interfaces.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Analysis> Analysis {  get; }
        IExamRepository Exam { get; }
        IPatientRepository Patient { get; }
        IMedicRepository Medic { get; }
        ITakeExamRepository TakeExam { get; }
    }
}
