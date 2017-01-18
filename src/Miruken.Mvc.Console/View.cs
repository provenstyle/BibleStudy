namespace Miruken.Mvc.Console
{
    using System;
    using System.Linq;
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

        public void ListenForMenu(Menu menu)
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine();
                Console.WriteLine("? Press Key:");
                var key = Console.ReadKey().Key;
                Console.WriteLine();
                Console.WriteLine();

                var item = menu.Items.FirstOrDefault(x => x.Key == key);
                if(item != null)
                   item.Action.Invoke();
                else
                {
                    Console.CursorTop = Console.CursorTop - 3;
                    Console.CursorLeft = 0;
                    Console.Write($"{key} is not expected.".PadRight(Pad));
                    ListenForMenu(menu);
                }
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

        public View Header(string title)
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

        public View WriteLine(string text = "")
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

    public class Menu
    {
        private readonly string    _menu;

        public MenuItem[] Items { get; }

        public Menu(params MenuItem[] items)
        {
            Items = items;
            var _builder = new StringBuilder();
            _builder.Append(" ");
            var itemsLength = Items.Length;
            for (var i = 0; i < itemsLength; i++)
            {
                var item = Items[i];
                _builder.Append($"{item.Text}({item.Key})");
                if (i < itemsLength - 1)
                    _builder.Append(" | ");
            }

            var menu = _builder.ToString();
            var separatorLength = menu.Length + 1;
            var separator = new string('-', separatorLength);
            _menu = new StringBuilder()
                .AppendLine(separator)
                .AppendLine(menu)
                .Append(separator)
                .ToString();
        }

        public override string ToString()
        {
            return _menu;
        }
    }

    public class MenuItem
    {
        public MenuItem(string text, ConsoleKey key, Action action)
        {
            Text   = text;
            Key    = key;
            Action = action;
        }

        public string     Text   { get; set; }
        public ConsoleKey Key    { get; set; }
        public Action     Action { get; set; }
    }
}
