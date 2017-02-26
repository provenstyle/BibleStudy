namespace BibleStudy.Data.Queries
{
    using System.Data.Entity;
    using System.Linq;
    using Api.Observations;
    using Entities;
    using Highway.Data;

    public class GetObservationsById : Query<ObservationData>
    {
        public GetObservationsById(int[] ids)
        {
            ContextQuery = c =>
               {
                   var query = Context.AsQueryable<Observation>().AsNoTracking();

                   if (ids?.Length == 1)
                   {
                       var id = ids[0];
                       query = query.Where(x => x.Id == id);
                   }
                   else if (ids?.Length > 1)
                   {
                       query = query.Where(x => ids.Contains(x.Id));
                   }

                   return query.Select(x => new ObservationData
                   {
                       Text = x.Text,
                   });
               };
        }
    }
}