namespace DomeinService.Models
{
    public class TreeModel
    {
        public int Id { get; set; }
        public string TreeName { get; set; }
        public int ParentNodeId { get; set; }
        public string NodeName { get; set; }
        public List<TreeModel> Children { get; set; }
    }
}
