using AutoMapper;
using DomeinService.Interfaces;
using DomeinService.Models;
using Infrastructyre.DataModels;
using Infrastructyre.Interfaces;

namespace DomeinService.Services
{
    public class TreeService : ITreeService
    {
        private ITreeRepository _treeRepository;
        private IJornalExeptionRepository _jornalExeptionRepository;
        private IMapper _mapper;
        public TreeService(ITreeRepository treeRepository
            , IJornalExeptionRepository jornalExeptionRepository
            , IMapper mapper)
        {
            _treeRepository = treeRepository;
            _jornalExeptionRepository = jornalExeptionRepository;
            _mapper = mapper;
        }

        public async Task<TreeModel> GetTree(string name)
        {
            try
            {
                var tree = await _treeRepository.GetTree(name);
                if (tree == null)
                {
                    await _treeRepository.CreateTree(name);
                }
                return _mapper.Map<TreeModel>(tree);
            }
            catch(Exception ex) 
            {
                var exeption = new ExceptionModel(ex.Message, "Problem with create tree", 500);

                await _jornalExeptionRepository.WreatExeption(_mapper.Map<JornalExeptionDataModel>(exeption));

                throw exeption;
            }
        }
    }
}
