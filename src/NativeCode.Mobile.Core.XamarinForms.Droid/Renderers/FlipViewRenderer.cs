using NativeCode.Mobile.Core.XamarinForms.Controls;
using NativeCode.Mobile.Core.XamarinForms.Droid.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FlipView), typeof(FlipViewRenderer))]

namespace NativeCode.Mobile.Core.XamarinForms.Droid.Renderers
{
    using System.ComponentModel;

    using NativeCode.Bindings.AndroidFlipView;
    using NativeCode.Mobile.Core.XamarinForms.Droid.Renderers.Adapters;

    using Xamarin.Forms.Platform.Android;

    using FlipView = NativeCode.Mobile.Core.XamarinForms.Controls.FlipView;
    using NativeFlipView = NativeCode.Bindings.AndroidFlipView.FlipView;
    using ViewExtensions = NativeCode.Mobile.Core.XamarinForms.Droid.Extensions.ViewExtensions;

    public class FlipViewRenderer : InflateViewRenderer<FlipView, NativeFlipView>,
                                    NativeFlipView.IOnFlipListener,
                                    NativeFlipView.IOnOverFlipListener,
                                    IFlipAdapterCallback
    {
        protected FlipAdapter FlipAdapter { get; private set; }

        public void OnFlippedToPage(NativeFlipView view, int position, long id)
        {
        }

        public void OnPageRequested(int position)
        {
            this.Control.SmoothFlipTo(position);
        }

        public void OnOverFlip(NativeFlipView view, OverFlipMode mode, bool overFlippingPrevious, float overFlipDistance, float flipDistancePerPage)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<FlipView> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                this.SetNativeControl(this.InflateNativeControl(Resource.Layout.flipview));
                this.SetFlipAdapter();

                this.Control.PeakNext(false);
                this.Control.SetOnFlipListener(this);
                this.Control.SetOnOverFlipListener(this);

                this.UpdateOverFlipMode();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == FlipView.FlipViewStyleProperty.PropertyName)
            {
                this.UpdateOverFlipMode();
            }
        }

        private void SetFlipAdapter()
        {
            this.Control.Adapter = this.FlipAdapter = new FlipAdapter(this);

            foreach (var view in this.Element.Views)
            {
                var renderer = ViewExtensions.GetRenderer(view);
                this.FlipAdapter.AddView(renderer.ViewGroup);
            }
        }

        private void UpdateOverFlipMode()
        {
            if (this.Element.FlipViewStyle == FlipViewStyle.RubberBand)
            {
                this.Control.OverFlipMode = OverFlipMode.RubberBand;
                return;
            }

            this.Control.OverFlipMode = OverFlipMode.Glow;
        }
    }
}