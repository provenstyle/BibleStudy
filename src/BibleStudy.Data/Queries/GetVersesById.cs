namespace BibleStudy.Data.Queries
{
    using System.Data.Entity;
    using System.Linq;
    using Api.Verses;
    using Entities;
    using Highway.Data;

    public class GetVersesById : Query<VerseData>
    {
        public GetVersesById(int[] ids)
        {
            ContextQuery = c =>
            {
                var query = Context.AsQueryable<Verse>().AsNoTracking();

                if (ids?.Length == 1)
                {
                    query = query.Where(x => x.Id == ids[0]);
                }
                else if (ids?.Length > 1)
                {
                    query = query.Where(x => ids.Contains(x.Id));
                }

                query = query.OrderBy(x => x.BookId)
                    .ThenBy(x => x.Chapter)
                    .ThenBy(x => x.Number);

                return query.Select(x => new VerseData
                 {
                    Id         = x.Id,
                    BookId     = x.BookId,
                    Chapter    = x.Chapter,
                    Number     = x.Number,
                    Text       = x.Text,
                    Created    = x.Created,
                    CreatedBy  = x.CreatedBy,
                    Modified   = x.Modified,
                    ModifiedBy = x.ModifiedBy,
                    RowVersion = x.RowVersion
                 });
            };
        }
    }
}
