namespace BibleStudy.Console.Features.Study
{
    using System;
    using Infrastructure;
    using Miruken.Mvc.Console;

    public class StudyView : FeatureView<StudyController>
    {
        public StudyView()
        {
            Menu = new Menu(
                new MenuItem("Observation", ConsoleKey.O, () => Controller.GoToObservation()),
                new MenuItem("Application", ConsoleKey.A, () => Controller.GoToApplication()),
                new MenuItem("Prayer",      ConsoleKey.P, () => Controller.GoToPrayer()));
        }

        public override void Initialize()
        {
            base.Initialize();

            Buffer.WriteLine("Study");
            Buffer.WriteLine();
            Buffer.WriteLine(Menu.ToString());
            Buffer.WriteLine();
            Buffer.WriteLine(Controller.Verse.ToString());
        }
    }
}
