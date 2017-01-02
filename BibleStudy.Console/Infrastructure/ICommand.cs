namespace BibleStudy.Console.Infrastructure
{
    public interface ICommand
    {
        bool CanProcess(string command);
        void Process(string command);
    }
}