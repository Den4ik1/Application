namespace Infrastructyre.DataModels
{
    public class TreeDataModel
    {
        public int Id { get; set; }
        public string TreeName { get; set; }
        public List<TreeNodeDataModel> Children { get; set; }
    }
}
