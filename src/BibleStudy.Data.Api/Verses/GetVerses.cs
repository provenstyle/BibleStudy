namespace BibleStudy.Data.Api.Verses
{
    using Improving.MediatR;

    public class GetVerses : Request.WithResponse<VerseResult>
    {
        public GetVerses()
        {
            Ids = new int[0];
        }

        public GetVerses(params int[] ids)
        {
            Ids = ids;
        }

        public int[] Ids { get; set;}
    }
}
