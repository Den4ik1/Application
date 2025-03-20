using Infrastructyre.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructyre.Data
{
    public class TreeDBContext : DbContext
    {
        public TreeDBContext(DbContextOptions<TreeDBContext> options)
                : base(options){}

        public DbSet<TreeDataModel> Tree { get; set; }
        public DbSet<TreeNodeDataModel> TreeNode { get; set; }
        public DbSet<JornalExeptionDataModel> JornalExeption { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TreeNodeDataModel>()
                .HasOne(a => a.TreeModel)
                .WithMany(p => p.Children)
                .HasForeignKey(a => a.TreeId);
        }
    }
}
