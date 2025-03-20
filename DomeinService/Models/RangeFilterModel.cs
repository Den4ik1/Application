namespace DomeinService.Models
{
    public class RangeFilterModel
    {
        public string Title { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
