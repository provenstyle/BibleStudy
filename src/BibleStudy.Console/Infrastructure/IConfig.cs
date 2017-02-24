namespace BibleStudy.Console.Infrastructure
{
    public interface IConfig
    {
        int?   ApiTimeout { get; }
        string UserName   { get; }
    }
}
