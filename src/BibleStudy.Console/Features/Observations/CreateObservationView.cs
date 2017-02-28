namespace BibleStudy.Console.Features.Observations
{
    using Infrastructure;
    using Miruken.Mvc.Console;

    public class CreateObservationView : FeatureView<CreateObservationController>
    {
        public override void Initialize()
        {
            base.Initialize();
            Buffer.WriteLine("Create Observation");
        }

        public void CompleteForm()
        {
            var form = new Form(
                new Question("What is your observation?", x => Controller.Observation.Text = x)
            );
            form.Handle(Buffer, InputLocation.Inline);
        }
    }
}
