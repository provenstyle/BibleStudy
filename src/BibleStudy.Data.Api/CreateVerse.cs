namespace BibleStudy.Data.Api
{
    using Improving.MediatR;

    public class CreateVerse : ResourceAction<VerseData, int>
    {
        public CreateVerse()
        {
        }

        public CreateVerse(VerseData verse)
            : base (verse)
        {
        }
    }

    public class VerseData : Resource<int>
    {
        public int?   BookId  { get; set; }
        public int?   Chapter { get; set; }
        public int?   Number  { get; set; }
        public string Text    { get; set; }
    }

    public class VerseResult
    {
        public VerseData[] Verses { get; set; }
    }
}
