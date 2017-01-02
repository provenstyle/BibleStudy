namespace BibleStudy.Console.Commands
{
    using System.Linq;
    using Infrastructure;

    public class Quit : BaseCommand
    {
        public string[] Commands = {"quit", "quite", "q", "exit"};
        public Lifecyle Lifecyle { get; set; }

        public override bool InternalCanProcess(string[] args)
        {
            return Commands.Contains(args[0]);
        }

        public override void InternalProcess(string[] args)
        {
            Lifecyle.Exit = true;
        }
    }
}