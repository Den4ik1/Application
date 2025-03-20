namespace DomeinService.Models
{
    public class TreeNodeModel
    {
        public int Id { get; set; }
        public string TreeName { get; set; }
        public int ParentNodeId { get; set; }
        public string NodeName { get; set; }
    }
}
