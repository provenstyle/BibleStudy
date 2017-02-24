namespace BibleStudy.Console.Infrastructure
{
    using System.Threading.Tasks;

    public interface ICommand
    {
        bool CanHandle(string command);
        Task Handle(string command);
    }
}