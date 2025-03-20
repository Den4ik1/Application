using DomeinService.Models;

namespace DomeinService.Interfaces
{
    public interface ITreeNodeService
    {
        public Task Create(string treeName, int parentNodeId, string nodeName);
        public Task Delete(string treeName, int nodeId);
        public Task Rename(string treeName, int nodeId, string newNodeName);
    }
}
