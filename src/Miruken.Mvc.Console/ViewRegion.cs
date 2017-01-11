namespace Miruken.Mvc.Console
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Threading;
    using Callback;
    using Context;
    using Infrastructure;
    using Options;
    using Views;

    public class ViewRegion : ViewContainer, IViewStackView
    {
        private bool _unwinding;

        public ViewRegion()
        {
            Layers = new List<ElementLayer>();
            Children = new List<View>();
            Policy.OnRelease(UnwindLayers);
        }

        private List<ElementLayer> Layers { get; }

        private View ActiveElement
        {
            get
            {
                var activeLayer = ActiveLayer;
                return activeLayer?.Element;
            }
        }

        private List<View> Children { get; set; }

        protected override IViewLayer Show(IView view, IHandler composer)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            var element = view as View;
            return element == null
                 ? Handler.Unhandled<IViewLayer>()
                 : TransitionTo(element, Handler.Composer);
        }

        private IViewLayer TransitionTo(View element, IHandler composer)
        {
            var options       = GetRegionOptions(composer);

            var          push    = false;
            var          overlay = false;
            ElementLayer layer   = null;

            var layerOptions = options?.Layer;

            if (Layers.Count == 0)
                push = true;
            else if (layerOptions != null)
            {
                if (layerOptions.Push == true)
                    push = true;
                else if (layerOptions.Overlay == true)
                {
                    push = overlay = true;
                }
                else if (layerOptions.Unload == true)
                {
                    UnwindLayers();
                    push = true;
                }
                else
                    layer = (ElementLayer) layerOptions.Choose(
                        Layers.Cast<IViewLayer>().ToArray());
            }

            if (push)
            {
                var pop     = overlay ? PushOverlay() : PushLayer();
                var context = composer.Resolve<IContext>();
                if (context != null)
                    context.ContextEnding += _ => pop.Dispose();
            }

            if (layer == null) layer = ActiveLayer;
            return layer.TransitionTo(element, options);
        }

        #region Layer Methods

        private ElementLayer ActiveLayer =>
            Layers.Count > 0 ? Layers[Layers.Count - 1]  : null;

        public IDisposable PushLayer()
        {
            return CreateLayer(false);
        }

        public IDisposable PushOverlay()
        {
            return CreateLayer(true);
        }

        public void UnwindLayers()
        {
            _unwinding = true;
            while (Layers.Count > 0)
                Layers.Last().Dispose();
            _unwinding = false;
        }

        private ElementLayer DropLayer(ElementLayer layer)
        {
            var index = Layers.IndexOf(layer);
            if (index <= 0) return null;
            Layers.RemoveAt(index);
            return Layers[index - 1];
        }

        private void RemoveLayer(ElementLayer layer)
        {
            Layers.Remove(layer);
            layer.TransitionFrom();
        }

        private ElementLayer CreateLayer(bool overlay)
        {
            var layer = new ElementLayer(this, overlay);
            Layers.Add(layer);
            return layer;
        }

        private int GetLayerIndex(ElementLayer layer)
        {
            return Layers.IndexOf(layer);
        }

        #endregion

        #region Helper Methods

        private void AddElement(
            View fromElement, View element, RegionOptions options)
        {
            if (_unwinding || Children.Contains(element)) return;

            var fromIndex = Children.IndexOf(fromElement);

            if (fromIndex >= 0)
                Children.Insert(fromIndex + 1, element);
            else
                Children.Add(element);

            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.SetWindowPosition(0,0);
            element.Loaded();
            element.Activate();
            element.Active = true;
        }
        private void RemoveElement(View element)
        {
            if (Children.Contains(element))
                Children.Remove(element);

            element.Active = false;
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.SetWindowPosition(0,0);

            var activeElement = ActiveElement;
            if (activeElement == null) return;

            activeElement.Active = true;
            Console.WriteLine(activeElement);
            activeElement.Activate();
        }

        private static RegionOptions GetRegionOptions(IHandler composer)
        {
            if (composer == null) return null;
            var options = new RegionOptions();
            return composer.Handle(options, true) ? options : null;
        }

        #endregion

        #region ElementLayer

        public class ElementLayer : IViewLayer
        {
            private readonly bool _overlay;
            private View _element;
            protected bool _disposed;

            public ElementLayer(ViewRegion region, bool overlay)
            {
                _overlay = overlay;
                Events   = new EventHandlerList();
                Region   = region;
            }

            protected ViewRegion       Region { get; }
            protected EventHandlerList Events { get; }

            public View Element
            {
                get { return _element; }
                set
                {
                    if (ReferenceEquals(_element, value))
                        return;
                    var view = (IView)_element;
                    if (Region.DoesDependOn(view))
                        view.Release();
                    _element = value;
                    if (_element != null)
                    {
                        var elementView = (IView)_element;
                        if (elementView.Policy.Parent == null)
                            Region.DependsOn(elementView);
                    }
                }
            }

            public int Index => Region.GetLayerIndex(this);

            public event EventHandler Transitioned
            {
                add { Events.AddHandler(TransitionedEvent, value); }
                remove { Events.RemoveHandler(TransitionedEvent, value); }
            } protected static readonly object TransitionedEvent = new object();

            public event EventHandler Disposed
            {
                add
                {
                    if (_disposed)
                        value(this, EventArgs.Empty);
                    else
                        Events.AddHandler(DisposedEvent, value);
                }
                remove { Events.RemoveHandler(DisposedEvent, value); }
            }

            protected static readonly object DisposedEvent = new object();

            public IViewLayer TransitionTo(View element, RegionOptions options)
            {
                if (ReferenceEquals(Element, element))
                    return this;

                // The initial animation will be captured
                // and used when the layer is transitioned from

                var oldElement = Element;
                if (_overlay && oldElement != null)
                {
                    var layer = Region.DropLayer(this);
                    if (layer != null)
                    {
                        var actual = layer.TransitionTo(element, options);
                        Region.RemoveElement(oldElement);
                        return actual;
                    }
                }

                Region.AddElement(Element, element, options);
                Element = element;
                if (oldElement != null)
                    Region.RemoveElement(oldElement);

                Events.Raise(this, TransitionedEvent);
                return this;
            }

            public void TransitionFrom()
            {
                var oldElement = Element;
                if ((oldElement != null) && !ReferenceEquals(oldElement, Region.ActiveElement))
                    Region.RemoveElement(oldElement);
                Element = null;
            }

            public IDisposable Duration(TimeSpan duration, Action<bool> complete)
            {
                DispatcherTimer timer = null;
                Action<bool, Action<bool>> stopTimer = (cancelled, c) =>
                {
                    var t = timer;
                    if (t == null) return;
                    timer = null;
                    t.IsEnabled = false;
                    c?.Invoke(cancelled);
                };

                EventHandler transitioned = null;
                EventHandler disposed = null;

                transitioned = (s, a) =>
                {
                    stopTimer(true, null);
                    Transitioned -= transitioned;
                    Disposed -= disposed;
                };
                Transitioned += transitioned;

                disposed = (s, a) =>
                {
                    stopTimer(false, null);
                    Disposed -= disposed;
                    Transitioned -= transitioned;
                };
                Disposed += disposed;

                timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(duration.TotalMilliseconds)
                };
                timer.Tick += (_, e) => stopTimer(false, complete);
                timer.IsEnabled = true;

                return new DisposableAction(() => stopTimer(true, complete));
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (_disposed || !disposing) return;
                try
                {
                    Region.RemoveLayer(this);
                }
                finally
                {
                    _disposed = true;
                    Events.Raise(this, DisposedEvent);
                    Events.Dispose();
                }
            }

            ~ElementLayer()
            {
                Dispose(false);
            }
        }

        #endregion
    }
}