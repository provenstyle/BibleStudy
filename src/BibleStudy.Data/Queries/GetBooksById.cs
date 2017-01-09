namespace BibleStudy.Data.Queries
{
    using System.Data.Entity;
    using System.Linq;
    using Entities;
    using Highway.Data;

    public class GetBooksById : Query<Book>
    {
        public GetBooksById(int[] ids)
        {
            ContextQuery = c =>
            {
                var query = Context.AsQueryable<Book>().AsNoTracking();

                if (ids?.Length == 1)
                {
                    query = query.Where(x => x.Id == ids[0]);
                }
                else if (ids?.Length > 1)
                {
                    query = query.Where(x => ids.Contains(x.Id));
                }

                return query.OrderBy(x => x.Id);
            };
        }
    }
}
