namespace Application.ViewModels
{
    public class TreeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Children { get; set; }
    }
}