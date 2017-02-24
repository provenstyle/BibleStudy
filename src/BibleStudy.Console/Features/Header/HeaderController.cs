namespace BibleStudy.Console.Features.Header
{
    using System;
    using Infrastructure;
    using Miruken.Concurrency;
    using Miruken.Context;
    using Verses;

    public class HeaderController : FeatureController
    {

        public Promise ShowHeader(IContext body)
        {
            Body = body;
            Show<HeaderView>();
            return Promise.Empty;
        }

        public Promise GoToVerses()
        {
            return Next<VersesController>(Body).ShowVerses();
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
