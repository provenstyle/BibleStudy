namespace BibleStudy.Console.Infrastructure
{
    using System.Threading.Tasks;

    public interface ICommand
    {
        bool CanProcess(string command);
        Task Process(string command);
    }
}