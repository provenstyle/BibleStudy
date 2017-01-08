using System.Threading.Tasks;

namespace BibleStudy.Console.Infrastructure
{
    using System;
    using System.Linq;

    public abstract class BaseCommand : ICommand
    {
        public bool CanProcess(string command)
        {
            var args = SplitArgs(command);
            return args.Any() && InternalCanProcess(args);
        }

        public async Task Process(string command)
        {
            await InternalProcess(SplitArgs(command));
            Console.WriteLine();
        }

        private static string[] SplitArgs(string command)
        {
            return command.IsNullOrEmpty()
                ? new string[0]
                : command.ToLower().Split(' ')
                    .Select(x => x.Trim()).ToArray();
        }

        public abstract bool InternalCanProcess(string[] args);
        public abstract Task InternalProcess(string[] args);
    }
}