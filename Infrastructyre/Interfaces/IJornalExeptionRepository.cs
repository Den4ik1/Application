using Infrastructyre.DataModels;

namespace Infrastructyre.Interfaces
{
    public interface IJornalExeptionRepository
    {
        public IQueryable<JornalExeptionDataModel> GetRange(JournalFilterDataModel filter);
        public Task WreatExeption(JornalExeptionDataModel exeption);
        public Task<JornalExeptionDataModel> ReadExeption(int id);
    }
}
