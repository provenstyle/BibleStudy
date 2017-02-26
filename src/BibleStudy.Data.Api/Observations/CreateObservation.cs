namespace BibleStudy.Data.Api.Observations
{
    using Improving.MediatR;

    public class CreateObservation : ResourceAction<ObservationData, int>
    {
        public CreateObservation()
        {
        }

        public CreateObservation(ObservationData observation)
            : base(observation)
        {
        }
    }
}