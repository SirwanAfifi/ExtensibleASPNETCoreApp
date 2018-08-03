namespace MvcCoreSample.DomainClasses
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public int Length { get; set; }
    }
}