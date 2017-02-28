namespace BibleStudy.Data.Maps
{
    using Entities;

    public class ObservationMap : BaseMap<Observation>
    {
        public ObservationMap()
        {
            ToTable(nameof(Observation));
        }
    }
}