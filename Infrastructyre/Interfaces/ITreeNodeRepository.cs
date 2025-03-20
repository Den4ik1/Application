using Infrastructyre.DataModels;

namespace Infrastructyre.Interfaces
{
    public interface ITreeNodeRepository
    {
        public Task CreateTreeNode(TreeNodeDataModel treeNode);
        public Task DeleteTreeNode(TreeNodeDataModel treeNode);
        public Task RenameTreeNode(TreeNodeDataModel treeNode);
        public Task<TreeNodeDataModel> GetNode(int id, string treeName);

    }
}
