using AutoMapper;
using DomeinService.Interfaces;
using DomeinService.Models;
using Infrastructyre.DataModels;
using Infrastructyre.Interfaces;

namespace DomeinService.Services
{
    public class JournalService : IJournalService
    {
        private IJornalExeptionRepository _jornalExeptionRepository;
        private IMapper _mapper;
        public JournalService(IJornalExeptionRepository jornalExeptionRepository, IMapper mapper)
        {
            _jornalExeptionRepository = jornalExeptionRepository;
            _mapper = mapper;
        }

        public List<JournalModel> GetRange(RangeFilterModel filter)
        {
            var filterDB = _mapper.Map<JournalFilterDataModel>(filter);
            return _mapper.Map<List<JournalModel>>(_jornalExeptionRepository.GetRange(filterDB));
        }

        public JournalModel GetSign(int Id)
        {
            return _mapper.Map<JournalModel>(_jornalExeptionRepository.ReadExeption(Id));
        }
    }
}
