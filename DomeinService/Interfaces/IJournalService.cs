using DomeinService.Models;

namespace DomeinService.Interfaces
{
    public interface IJournalService
    {
        public List<JournalModel> GetRange(RangeFilterModel filter);
        public JournalModel GetSign(int Id);
    }
}
