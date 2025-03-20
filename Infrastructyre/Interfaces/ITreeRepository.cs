using Infrastructyre.DataModels;

namespace Infrastructyre.Interfaces
{
    public interface ITreeRepository
    {
        public Task<TreeDataModel> GetTree(string name);
        public Task<TreeDataModel> CreateTree(string name);

    }
}
