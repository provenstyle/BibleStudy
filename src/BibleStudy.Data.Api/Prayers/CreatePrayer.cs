namespace BibleStudy.Data.Api.Prayers
{
    using Improving.MediatR;

    public class CreatePrayer : ResourceAction<PrayerData, int>
    {
        public CreatePrayer()
        {
        }

        public CreatePrayer(PrayerData prayer)
            : base (prayer)
        {
        }
    }
}