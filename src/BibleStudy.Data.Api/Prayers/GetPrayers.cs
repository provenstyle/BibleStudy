namespace BibleStudy.Data.Api.Prayers
{
    using Improving.MediatR;

    public class GetPrayers : Request.WithResponse<PrayerResult>
    {
        public GetPrayers()
        {
            Ids = new int[0];
        }

        public GetPrayers(params int[] ids)
        {
            Ids = ids;
        }

        public int[] Ids { get; set;}
    }
}