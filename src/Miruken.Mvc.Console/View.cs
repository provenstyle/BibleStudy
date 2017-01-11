namespace Miruken.Mvc.Console
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Views;

    public abstract class View : IView
    {
        private StringBuilder Builder { get; }

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

        public override string ToString()
        {
            return Builder.ToString();
        }

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

        protected View Seperator(char character = '-')
        {
            WriteLine(new string(character, Console.WindowWidth));
            return this;
        }

        protected View Header(string title)
        {
            Seperator();
            WriteLine($" {title}");
            Seperator();
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
            Console.CursorTop = Console.CursorTop - 3;
            Console.CursorLeft = 0;
            Console.WriteLine($"{line} is not recognized.".PadRight(Console.WindowWidth));
            ListenForLine();
        }

        protected void Unrecognized(ConsoleKey key)
        {
            Console.CursorTop = Console.CursorTop - 3;
            Console.CursorLeft = 0;
            Console.Write($"{key} is not expected.".PadRight(Console.WindowWidth));
            ListenForKey();
        }

        protected void Menu(params MenuItem[] items)
        {
            var builder = new StringBuilder();
            builder.Append(" ");
            var length = items.Length;
            for (var i = 0; i < length; i++)
            {
                var item = items[i];
                builder.Append($"{item.Text}({item.Key})");
                if (i < length - 1)
                    builder.Append(" | ");
            }
            WriteLine(builder.ToString());
        }
    }

    public abstract class View<C> : View
        where C : class, IController
    {
        public C Controller => (C) ViewModel;
    }

    public class MenuItem
    {
        public MenuItem(string text, ConsoleKey key)
        {
            Text = text;
            Key  = key;
        }
        public string     Text { get; set; }
        public ConsoleKey Key  { get; set; }
    }
}
