namespace BibleStudy.Data.Api
{
    using System;
    using System.Threading.Tasks;
    using Entities;
    using MediatR;

    public class VerseAggregateHandler : IAsyncRequestHandler<CreateVerse, VerseData>
    {
        public async Task<VerseData> Handle(CreateVerse message)
        {
            var verse = Map(new Verse(), message.Resource);

            //save it here

            return new VerseData
            {
                Id = verse.Id,
                RowVersion = verse.RowVersion
            };
        }

        public Verse Map(Verse verse, VerseData data)
        {
            if (data.BookId.HasValue)
                verse.BookId = data.BookId.Value;

            if (data.Chapter.HasValue)
                verse.Chapter = data.Chapter.Value;

            if (data.Number.HasValue)
                verse.Number = data.Number.Value;

            if (data.Text != null)
                verse.Text = data.Text;

            verse.Modified = DateTime.Now;

            return verse;
        }

    }
}
