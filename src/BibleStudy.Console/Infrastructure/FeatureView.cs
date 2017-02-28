namespace BibleStudy.Console.Infrastructure
{
    using System;
    using Miruken.Mvc;
    using Miruken.Mvc.Console;
    using Buffer = Miruken.Mvc.Console.Buffer;

    public abstract class FeatureView<C> : View<C> where C : class, IController
    {
        protected Menu   Menu;
        protected Buffer Buffer;

        protected FeatureView()
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