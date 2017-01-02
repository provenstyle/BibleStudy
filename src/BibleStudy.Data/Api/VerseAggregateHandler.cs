﻿namespace BibleStudy.Data.Api
{
    using System;
    using System.Threading.Tasks;
    using Entities;
    using Highway.Data.Repositories;
    using MediatR;

    public class VerseAggregateHandler : IAsyncRequestHandler<CreateVerse, VerseData>
    {
        private readonly IDomainRepository<BibleStudyDomain> _repository;

        public VerseAggregateHandler(IDomainRepository<BibleStudyDomain> repository)
        {
            _repository = repository;
        }

        public async Task<VerseData> Handle(CreateVerse message)
        {
            var verse = Map(new Verse(), message.Resource);

            _repository.Context.Add(verse);
            await _repository.Context.CommitAsync();

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
