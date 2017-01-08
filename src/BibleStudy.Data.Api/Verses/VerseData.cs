namespace BibleStudy.Data.Api.Verses
{
    using Improving.MediatR;

    public class VerseData : Resource<int>
    {
        public int?   BookId  { get; set; }
        public int?   Chapter { get; set; }
        public int?   Number  { get; set; }
        public string Text    { get; set; }
    }
}