﻿namespace BibleStudy.Console.Commands
{
    using System;
    using System.Threading.Tasks;
    using Infrastructure;
    using MediatR;

    public class Clear : BaseCommand
    {
        public Clear(IMediator mediator)
            : base(mediator)
        {
        }

        protected override bool InternalCanProcess(string[] args)
        {
            return args[0] == "clear";
        }

        protected override Task InternalProcess(string[] args)
        {
            Console.Clear();
            return Task.FromResult(true);
        }

        public override HelpData HelpData => new HelpData
        {
            Command     = "clear",
            Description = "Clear the console"
        };
    }
}
