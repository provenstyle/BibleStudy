namespace BibleStudy.Console.Features.Observations
{
    using Infrastructure;
    using Miruken.Mvc.Console;
    using Prayers;

    public class CreatePrayerView : FeatureView<CreatePrayerController>
    {
        public override void Initialize()
        {
            base.Initialize();
            Buffer.WriteLine("Create Prayer");
        }

        public void CompleteForm()
        {
            var form = new Form(
                new Question("Prayer?", x => Controller.Prayer.Text = x)
            );
            form.Handle(Buffer, InputLocation.Inline);
        }
    }
}
