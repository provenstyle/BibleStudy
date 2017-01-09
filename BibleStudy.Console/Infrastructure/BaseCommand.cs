namespace BibleStudy.Console.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class BaseCommand : ICommand, IHelp
    {
        public const string Seperator = "==================================================";
        public static bool  Quit      = false;

        public abstract HelpData HelpData { get; }

        public bool CanProcess(string command)
        {
            var args = SplitArgs(command);
            return args.Any() && InternalCanProcess(args);
        }

        public async Task Process(string command)
        {
            Console.WriteLine();
            Console.WriteLine(Seperator);
            await InternalProcess(SplitArgs(command));

            if (!Quit)
            {
                Console.WriteLine();
                Console.WriteLine(Seperator);
                Console.WriteLine();
                Console.WriteLine("Next?");
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
            Console.WriteLine(title);
            Console.WriteLine(Seperator);
            Console.WriteLine();
            return this;
        }
    }
}