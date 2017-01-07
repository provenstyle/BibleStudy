namespace BibleStudy.Data.Entities
{
    using Improving.MediatR;

    public class Testament : IKeyProperties<int>
    {
        public int    Id   { get; set; }
        public string Name { get; set; }
    }
}
