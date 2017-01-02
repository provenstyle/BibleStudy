namespace BibleStudy.Data.Entities
{
    using Improving.MediatR;

    public class Testament : Entity, IKeyProperties<int>
    {
        public string Name { get; set; }
    }
}
