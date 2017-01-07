namespace BibleStudy.Data.Entities
{
    using Improving.MediatR;

    public class Book : IKeyProperties<int>
    {
        public int    Id                   { get; set; }
        public string Name                 { get; set; }
        public int    TestamentId          { get; set; }

        public virtual Testament Testament { get; set; }
    }
}
