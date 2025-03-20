using Infrastructyre.Data;
using Infrastructyre.DataModels;
using Infrastructyre.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructyre.Repositories
{
    public class TreeRepository : ITreeRepository
    {
        private TreeDBContext _context;

        public TreeRepository(TreeDBContext context) 
        {
            _context= context;
        }
        
        public async Task<TreeDataModel> GetTree(string name)
        {
            return await _context.Tree.FirstOrDefaultAsync(x => x.TreeName == name); ;
        }

        public async Task<TreeDataModel> CreateTree(string name)
        {
            var tree = new TreeDataModel { TreeName = name };
            _context.Tree.Add(tree);
            await _context.SaveChangesAsync();
            return tree;
        }
    }
}
