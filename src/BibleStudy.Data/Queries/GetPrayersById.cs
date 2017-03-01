namespace BibleStudy.Data.Queries
{
    using System.Data.Entity;
    using System.Linq;
    using Api.Prayers;
    using Highway.Data;
    using Prayer = Entities.Prayer;

    public class GetPrayersById : Query<PrayerData>
    {
        public GetPrayersById(int[] ids)
        {
            ContextQuery = c =>
               {
                   var query = Context.AsQueryable<Prayer>().AsNoTracking();

                   if (ids?.Length == 1)
                   {
                       var id = ids[0];
                       query = query.Where(x => x.Id == id);
                   }
                   else if (ids?.Length > 1)
                   {
                       query = query.Where(x => ids.Contains(x.Id));
                   }

                   return query.Select(x => new PrayerData
                   {
                       Text = x.Text,
                   });
               };
        }
    }
}