namespace BibleStudy.Data.Api.Observations
{
    using Improving.MediatR;

    public class ObservationData : Resource<int>
    {
        public string Text { get; set; }
    }
}
