using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistences.Context;

namespace CLINICAL.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public IGenericRepository<Analysis> Analysis {  get; }

        public IExamRepository Exam {  get; }

        public IPatientRepository Patient { get; }

        public IMedicRepository Medic {  get; }

        public ITakeExamRepository TakeExam {  get; }

        public UnitOfWork(AppDbContext appDbContext, IGenericRepository<Analysis> analysis)
        {
            _appDbContext = appDbContext;
            Analysis = analysis;
            Exam = new ExamRepository(_appDbContext);
            Patient = new PatientRepository(_appDbContext);
            Medic = new MedicRepository(_appDbContext);
            TakeExam = new TakeExamRepository(_appDbContext);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
