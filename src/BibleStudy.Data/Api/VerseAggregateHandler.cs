﻿using BibleStudy.Data.Api.Verses;

namespace BibleStudy.Data.Api
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Commands;
    using Entities;
    using Highway.Data.Repositories;
    using MediatR;

    public class VerseAggregateHandler :
        IAsyncRequestHandler<CreateVerse, VerseData>,
        IAsyncRequestHandler<GetVerses, VerseResult>
    {
        private readonly IDomainRepository<BibleStudyDomain> _repository;
        private readonly DateTime                            _now;

        public VerseAggregateHandler(IDomainRepository<BibleStudyDomain> repository)
        {
            _repository = repository;
            _now        = DateTime.Now;
        }

        public async Task<VerseData> Handle(CreateVerse message)
        {
            var verse = Map(new Verse(), message.Resource);
            verse.Created = _now;

            _repository.Context.Add(verse);
            await _repository.Context.CommitAsync();

            return new VerseData
            {
                Id = verse.Id,
                RowVersion = verse.RowVersion
            };
        }

        public async Task<VerseResult> Handle(GetVerses message)
        {
            var verses = await _repository.FindAsync(new GetVersesById(message.VerseIds));

            return new VerseResult
            {
                Verses = verses.ToArray()
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

            if (data.CreatedBy != null)
                verse.CreatedBy = data.CreatedBy;

            if (data.ModifiedBy != null)
                verse.ModifiedBy = data.ModifiedBy;

            verse.Modified = _now;

            return verse;
        }

    }
}
