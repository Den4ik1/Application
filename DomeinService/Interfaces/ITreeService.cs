using DomeinService.Models;

namespace DomeinService.Interfaces
{
    public interface ITreeService
    {
        public Task<TreeModel> GetTree(string name);
    }
}
