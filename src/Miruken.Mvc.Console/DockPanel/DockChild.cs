namespace Miruken.Mvc.Console
{
    using System;

    public class DockChild : IHaveFrameworkElement
    {
        private decimal _percent;

        public FrameworkElement Element { get; set; }

        public Dock             Dock    { get; set; }

        public decimal Percent
        {
            get
            {
                return _percent;
            }
            set
            {
                if(value < 0 || value > 100)
                    throw new ArgumentException("Must be between 0 and 100 inclusive.");
                _percent = value;
            }
        }
    }
}