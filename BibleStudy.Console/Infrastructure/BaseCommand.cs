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

        public void Process(string command)
        {
            InternalProcess(SplitArgs(command));
        }

        private static string[] SplitArgs(string command)
        {
            return command.IsNullOrEmpty() 
                ? new string[0] 
                : command.ToLower().Split(' ')
                    .Select(x => x.Trim()).ToArray();
        }

        public abstract bool InternalCanProcess(string[] args);
        public abstract void InternalProcess(string[] args);
    }
}