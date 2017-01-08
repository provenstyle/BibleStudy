namespace BibleStudy.Data.Api.Verses
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
}
