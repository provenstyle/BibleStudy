namespace BibleStudy.Console.Features.Header
{
    using System;
    using About;
    using Books;
    using Infrastructure;
    using Miruken.Concurrency;
    using Miruken.Context;
    using Verses;

    public class HeaderController : FeatureController
    {
        private IContext _body;

        public Promise ShowHeader(IContext body)
        {
            _body = body;
            Show<HeaderView>();
            return Promise.Empty;
        }

        public Promise GoToAbout()
        {
            return Next<AboutController>(_body).ShowAbout();
        }

        public Promise GoToBooks()
        {
            return Next<BooksController>(_body).ShowBooks();
        }

        public Promise GoToVerses()
        {
            return Next<VersesController>(_body).ShowVerses();
        }

        public Promise GoToObservations()
        {
            throw new NotImplementedException();
            //Next<TeamsController>(_body).ShowTeams();
        }

        public Promise GoToPrayers()
        {
            throw new NotImplementedException();
            //Next<TeamsController>(_body).ShowTeams();
        }

        public Promise GoToTags()
        {
            throw new NotImplementedException();
            //Next<PlayersController>(_body).ShowPlayers();
        }
    }
}
