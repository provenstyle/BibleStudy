namespace BibleStudy.Console.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Api.Books;
    using MediatR;

    public abstract class BaseCommand : ICommand, IHelp
    {
        protected readonly IMediator Mediator;
        public const string Seperator = "--------------------------------------------------";
        public static bool  Quit      = false;

        public abstract HelpData HelpData { get; }

        protected BaseCommand(IMediator mediator)
        {
            Mediator = mediator;
        }

        public bool CanProcess(string command)
        {
            var args = SplitArgs(command);
            return args.Any() && InternalCanProcess(args);
        }

        public async Task Process(string command)
        {
            Console.WriteLine();
            await InternalProcess(SplitArgs(command));

            if (!Quit)
            {
                Console.WriteLine();
                Console.WriteLine("?");
            }
        }

        private static string[] SplitArgs(string command)
        {
            return command.IsNullOrEmpty()
                ? new string[0]
                : command.ToLower().Split(' ')
                    .Select(x => x.Trim()).ToArray();
        }

        protected abstract bool InternalCanProcess(string[] args);
        protected abstract Task InternalProcess(string[] args);

        protected BaseCommand Header(string title)
        {
            Console.WriteLine(Seperator);
            Console.WriteLine(title);
            Console.WriteLine(Seperator);
            Console.WriteLine();
            return this;
        }

        protected BaseCommand Footer()
        {
            Console.WriteLine();
            Console.WriteLine(Seperator);
            return this;
        }

        protected bool Another()
        {
            Console.WriteLine();
            Console.WriteLine("Another? Press 'Y'");
            var input = Console.ReadKey().Key == ConsoleKey.Y;
            Console.WriteLine();
            Console.WriteLine();
            return input;
        }

        protected Task Done()
        {
            return Task.FromResult(true);
        }

        protected string PromptForString(string prompt)
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine()?.Trim();
            Console.WriteLine();
            return input;
        }

        protected int PromptForInt(string prompt)
        {
            Console.WriteLine(prompt);
            int value;
            while(!int.TryParse(Console.ReadLine(), out value))
            {
            }
            Console.WriteLine();
            return value;
        }

        protected async Task<BookData> PromptForBook()
        {
            var books = (await Mediator.SendAsync(new GetBooks())).Books;
            BookData book = null;
            do
            {
                var input = PromptForString("Book:");
                book      = books.FirstOrDefault(x => string.Equals(x.Name, input, StringComparison.CurrentCultureIgnoreCase));
                if (book == null)
                {
                    Console.WriteLine($"{input} is not a valid book");
                }
                Console.WriteLine();
            } while(book == null);
            return book;
        }

    }
}