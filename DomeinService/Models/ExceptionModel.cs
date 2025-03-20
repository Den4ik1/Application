namespace DomeinService.Models
{
    public class ExceptionModel : Exception
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int StatusCode { get; }

        public ExceptionModel(string message, string name, int statusCode) : base(message)
        {
            Name = name;
            StatusCode = statusCode;
        }
    }
}
