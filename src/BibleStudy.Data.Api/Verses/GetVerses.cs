namespace BibleStudy.Data.Api.Verses
{
    using Improving.MediatR;

    public class GetVerses : Request.WithResponse<VerseResult>
    {
        public GetVerses()
        {
            VerseIds = new int[0];
        }

        public GetVerses(params int[] verseIds)
        {
            VerseIds = verseIds;
        }

        public int[] VerseIds      { get; set;}
    }
}
