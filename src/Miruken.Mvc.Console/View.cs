namespace Miruken.Mvc.Console
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Views;

    public abstract class View : IView
    {
        protected View()
        {
            Builder = new StringBuilder();
        }

        public    abstract void Loaded();

        public    abstract void Activate();

        protected abstract void LineIn(string line);

        protected abstract void KeyIn(ConsoleKey key);

        #region IView

        private ViewPolicy _policy;

        public ViewPolicy Policy
        {
            get { return _policy ?? (_policy = new ViewPolicy(this)); }
            set { _policy = value; }
        }

        public object      ViewModel  { get; set; }

        public virtual IViewLayer Display(IViewRegion region)
        {
            return region?.Show(this);
        }

        #endregion

        public bool Active { get; set; }

        public void ListenForLine()
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine();
                Console.WriteLine("? Type then enter:");
                var line = Console.ReadLine()?.Trim().ToLower();
                Console.WriteLine();
                LineIn(line);
            });
        }

        public void ListenForKey()
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine();
                Console.WriteLine("? Press Key:");
                var key = Console.ReadKey().Key;
                Console.WriteLine();
                Console.WriteLine();
                KeyIn(key);
            });
        }


        protected const string Seperator = "--------------------------------------------------";

        private StringBuilder Builder { get; }

        public override string ToString()
        {
            return Builder.ToString();
        }

        protected View Header(string title)
        {
            WriteLine(Seperator);
            WriteLine(title);
            WriteLine(Seperator);
            WriteLine();
            return this;
        }

        protected View Write(string text)
        {
            Builder.Append(text);
            Console.Write(text);
            return this;
        }

        protected View WriteLine(string text = "")
        {
            Builder.AppendLine(text);
            Console.WriteLine(text);
            return this;
        }

        protected void Unrecognized(string line)
        {
            WriteLine($"{line} is not recognized.");
            ListenForLine();
        }

        protected void Unrecognized(ConsoleKey key)
        {
            WriteLine($"{key} is not expected.");
            ListenForKey();
        }
    }

    public abstract class View<C> : View
        where C : class, IController
    {
        public C Controller => (C) ViewModel;
    }
}
