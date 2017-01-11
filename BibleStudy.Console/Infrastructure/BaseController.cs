namespace BibleStudy.Console.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Commands;
    using Data.Api.Books;
    using MediatR;
    using Miruken.Mvc;

    public abstract class BaseController : Controller
    {
        protected readonly IMediator Mediator;

        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}