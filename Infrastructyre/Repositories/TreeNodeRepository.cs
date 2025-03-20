using Infrastructyre.Data;
using Infrastructyre.DataModels;
using Infrastructyre.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructyre.Repositories
{
    public class TreeNodeReepository : ITreeNodeRepository
    {
        private TreeDBContext _context;

        public TreeNodeReepository(TreeDBContext context)
        {
            _context = context;
        }

        public async Task<TreeNodeDataModel> GetNode(int id, string treeName)
        {
            return await _context.TreeNode
                .FirstOrDefaultAsync(x => x.Id == id && x.TreeName == treeName);
        }

        public async Task CreateTreeNode(TreeNodeDataModel node)
        {
                _context.TreeNode.Add(node);
                await _context.SaveChangesAsync();
        }

        public async Task DeleteTreeNode(TreeNodeDataModel node)
        {
           _context.Remove(node);
            await _context.SaveChangesAsync();
        }

        public async Task RenameTreeNode(TreeNodeDataModel node)
        {
                _context.Update(node);
                await _context.SaveChangesAsync();
        }
    }
}
