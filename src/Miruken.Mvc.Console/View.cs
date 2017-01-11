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
            return Seperator(Console.WindowWidth - 1, character);
        }

        protected View Seperator(int length, char character = '-')
        {
            WriteLine(new string(character, length));
            return this;
        }

        protected View Header(string title)
        {
            Seperator();
            WriteLine($"{title}");
            Seperator();
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
            Console.WriteLine($"{line} is not recognized.".PadRight(Pad));
            ListenForLine();
        }

        protected void Unrecognized(ConsoleKey key)
        {
            Console.CursorTop = Console.CursorTop - 3;
            Console.CursorLeft = 0;
            Console.Write($"{key} is not expected.".PadRight(Pad));
            ListenForKey();
        }

        protected void Menu(params MenuItem[] items)
        {
            var builder = new StringBuilder();
            builder.Append(" ");
            var itemsLength = items.Length;
            for (var i = 0; i < itemsLength; i++)
            {
                var item = items[i];
                builder.Append($"{item.Text}({item.Key})");
                if (i < itemsLength - 1)
                    builder.Append(" | ");
            }

            var menu = builder.ToString();
            var separatorLength = menu.Length + 1;
            Seperator(separatorLength);
            WriteLine(menu);
            Seperator(separatorLength);
        }

        protected View Block(string text )
        {
            WriteLine();
            WriteLine(text);
            WriteLine();
            return this;
        }

        private int Pad => Console.WindowWidth - 1;
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
