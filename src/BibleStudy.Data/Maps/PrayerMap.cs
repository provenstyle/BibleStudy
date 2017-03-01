namespace BibleStudy.Data.Maps
{
    using Entities;

    public class PrayerMap : BaseMap<Prayer>
    {
        public PrayerMap()
        {
            ToTable(nameof(Prayer));
        }
    }
}