namespace BibleStudy.Data.Api.Books
{
    using Improving.MediatR;

    public class GetBooks : Request.WithResponse<BookResult>
    {
        public GetBooks()
        {
            Ids = new int[0];
        }

        public GetBooks(params int[] ids)
        {
            Ids = ids;
        }

        public int[] Ids { get; set; }
    }
}
