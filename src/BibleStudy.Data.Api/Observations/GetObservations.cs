namespace BibleStudy.Data.Api.Observations
{
    using Improving.MediatR;

    public class GetObservations : Request.WithResponse<ObservationResult>
    {
        public GetObservations()
        {
            Ids = new int[0];
        }

        public GetObservations(params int[] ids)
        {
            Ids = ids;
        }

        public int[] Ids { get; set; }
    }
}