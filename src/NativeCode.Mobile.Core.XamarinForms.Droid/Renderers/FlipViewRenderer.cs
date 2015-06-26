using NativeCode.Mobile.Core.XamarinForms.Controls;
using NativeCode.Mobile.Core.XamarinForms.Droid.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FlipView), typeof(FlipViewRenderer))]

namespace NativeCode.Mobile.Core.XamarinForms.Droid.Renderers
{
    using System;
    using System.ComponentModel;

    using Android.Views;

    using NativeCode.Bindings.AndroidFlipView;
    using NativeCode.Mobile.Core.XamarinForms.Droid.Renderers.Adapters;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    using FlipView = NativeCode.Mobile.Core.XamarinForms.Controls.FlipView;
    using NativeFlipView = NativeCode.Bindings.AndroidFlipView.FlipView;

    public class FlipViewRenderer : NativeFlipView, IVisualElementRenderer, NativeFlipView.IOnFlipListener, NativeFlipView.IOnOverFlipListener
    {
        public FlipViewRenderer() : base(Forms.Context)
        {
        }

        public event EventHandler<VisualElementChangedEventArgs> ElementChanged;

        public VisualElement Element { get; private set; }

        public VisualElementTracker Tracker { get; private set; }

        public ViewGroup ViewGroup
        {
            get { return this; }
        }

        protected FlipAdapter FlipAdapter { get; private set; }

        protected FlipView FlipViewElement
        {
            get { return (FlipView)this.Element; }
        }

        public void OnFlippedToPage(NativeFlipView view, int position, long id)
        {
            this.UpdateContent(position);
        }

        public void OnOverFlip(NativeFlipView view, OverFlipMode mode, bool overFlippingPrevious, float overFlipDistance, float flipDistancePerPage)
        {
        }

        public void SetElement(VisualElement element)
        {
            var oldElement = this.Element;
            var newElement = element;

            this.Element = newElement;

            if (oldElement != null)
            {
                oldElement.PropertyChanged -= this.HandlePropertyChanged;
            }

            if (oldElement == null && newElement != null)
            {
                newElement.PropertyChanged += this.HandlePropertyChanged;

                this.RemoveAllViews();

                this.Adapter = this.FlipAdapter = this.CreateAdapter();
                this.Tracker = new VisualElementTracker(this);

                this.PeakNext(true);
                this.SetOnFlipListener(this);
                this.SetOnOverFlipListener(this);

                this.FlipAdapter.Invalidate();
                this.UpdateContent(0);
            }

            this.OnElementChanged(new VisualElementChangedEventArgs(oldElement, newElement));
        }

        public SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
        {
            this.Measure(widthConstraint, heightConstraint);

            return new SizeRequest(new Size(widthConstraint, heightConstraint));
        }

        public void UpdateLayout()
        {
            if (this.Tracker != null)
            {
                this.Tracker.UpdateLayout();
            }
        }

        protected virtual void OnElementChanged(VisualElementChangedEventArgs e)
        {
            var handler = this.ElementChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private FlipAdapter CreateAdapter()
        {
            var adapter = new FlipAdapter(this.FlipViewElement.ContentProvider);

            return adapter;
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == FlipView.FlipViewStyleProperty.PropertyName)
            {
                this.UpdateFlipViewStyle();
            }
        }

        private void UpdateFlipViewStyle()
        {
            this.OverFlipMode = this.FlipViewElement.FlipViewStyle == FlipViewStyle.RubberBand ? OverFlipMode.RubberBand : OverFlipMode.Glow;
        }

        private void UpdateContent(int position)
        {
            this.FlipViewElement.Content = this.FlipViewElement.ContentProvider.GetContent(position);
        }
    }
}