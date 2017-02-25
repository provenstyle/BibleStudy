namespace BibleStudy.Console.Features.Study
{
    using System;
    using Miruken.Mvc;
    using Miruken.Mvc.Console;
    using Buffer = Miruken.Mvc.Console.Buffer;

    public class StudyView : BaseView<StudyController>
    {
        public StudyView()
        {
            Menu = new Menu(
                new MenuItem("Observation", ConsoleKey.O, () => Controller.Observation()),
                new MenuItem("Application", ConsoleKey.A, () => Controller.Observation()),
                new MenuItem("Prayer",      ConsoleKey.P, () => Controller.Observation()));
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

    public abstract class BaseView<C> : View<C> where C : class, IController
    {
        protected Menu   Menu;
        protected Buffer Buffer;

        protected BaseView()
        {
            Buffer = new Buffer();
            Content = Buffer;
        }

        public override void KeyPressed(ConsoleKeyInfo keyInfo)
        {
            base.KeyPressed(keyInfo);
            Menu?.Listen(keyInfo);
        }
    }
}
