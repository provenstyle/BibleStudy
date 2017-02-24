namespace BibleStudy.Console.Infrastructure
{
    public interface IHelp
    {
        HelpData HelpData { get; }
    }

    public class HelpData
    {
        public string Command { get; set; }
        public string Description { get; set; }
    }
}
