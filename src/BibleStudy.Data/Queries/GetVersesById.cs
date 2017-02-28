namespace BibleStudy.Data.Queries
{
    using System.Data.Entity;
    using System.Linq;
    using Entities;
    using Highway.Data;

    public class GetVersesById : Query<Verse>
    {
        public bool IncludeObservations { get; set; }

        public GetVersesById(int[] ids)
        {
            ContextQuery = c =>
            {
                var query = Context.AsQueryable<Verse>().AsNoTracking();

                if (ids?.Length == 1)
                {
                    var id = ids[0];
                    query = query.Where(x => x.Id == id);
                }
                else if (ids?.Length > 1)
                {
                    query = query.Where(x => ids.Contains(x.Id));
                }

                if (IncludeObservations)
                    query = query.Include(v => v.VerseObservations.Select(vo => vo.Observation));

                return query.OrderBy(x => x.BookId)
                    .ThenBy(x => x.Chapter)
                    .ThenBy(x => x.Number);
            };
        }
    }
}
