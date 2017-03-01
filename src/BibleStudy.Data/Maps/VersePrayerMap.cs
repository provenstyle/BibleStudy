namespace BibleStudy.Data.Maps
{
    using Entities;

    public class VersePrayerMap : BaseMap<VersePrayer>
    {

        public VersePrayerMap()
        {
            ToTable(nameof(VersePrayer));
        }
    }
}