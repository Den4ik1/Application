namespace Infrastructyre.DataModels
{
    public class TreeNodeDataModel
    {
        public int Id { get; set; }
        public string TreeName { get; set; }
        public string NodeName { get; set; }
        public int? ParentNodeId { get; set; }

        public int TreeId { get; set; }
        public TreeDataModel TreeModel { get; set; }

        public List<TreeNodeDataModel> TreeNodeDataModels { get; set; } = new List<TreeNodeDataModel>();
    }
}
