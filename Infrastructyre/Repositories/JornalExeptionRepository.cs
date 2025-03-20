using Infrastructyre.Data;
using Infrastructyre.DataModels;
using Infrastructyre.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructyre.Repositories
{
    public class JornalExeptionRepository : IJornalExeptionRepository
    {
        private TreeDBContext _context;

        public JornalExeptionRepository(TreeDBContext context) 
        {
            _context= context;
        }

        public IQueryable<JornalExeptionDataModel> GetRange(JournalFilterDataModel filter)
        {
            return  _context.JornalExeption.Where(x => x.Name == filter.Title
                    && x.CreatedAt >= filter.From
                    && x.CreatedAt <= filter.To).AsQueryable()
                    .Skip(filter.Skip)
                    .Take(filter.Take);
        }

        public async Task<JornalExeptionDataModel> ReadExeption(int Id)
        {
            return await _context.JornalExeption.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task WreatExeption(JornalExeptionDataModel exeption)
        {
            _context.JornalExeption.Add(exeption);
            await _context.SaveChangesAsync();
        }
    }
}
