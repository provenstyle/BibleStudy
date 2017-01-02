namespace BibleStudy.Data.Entities
{
    using Improving.MediatR;

    public class Book : Entity, IKeyProperties<int>
    {
        public string Name                 { get; set; }
        public int    TestamentId          { get; set; }

        public virtual Testament Testament { get; set; }
    }
}
