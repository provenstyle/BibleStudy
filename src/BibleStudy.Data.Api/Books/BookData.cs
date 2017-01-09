namespace BibleStudy.Data.Api.Books
{
    using Improving.MediatR;

    public class BookData : IKeyProperties<int>
    {
        public int           Id        { get; set; }
        public string        Name      { get; set; }
        public TestamentData Testament { get; set; }
    }
}