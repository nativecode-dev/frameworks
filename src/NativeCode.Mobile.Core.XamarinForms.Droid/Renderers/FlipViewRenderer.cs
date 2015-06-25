using NativeCode.Mobile.Core.XamarinForms.Controls;
using NativeCode.Mobile.Core.XamarinForms.Droid.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FlipView), typeof(FlipViewRenderer))]

namespace NativeCode.Mobile.Core.XamarinForms.Droid.Renderers
{
    using NativeCode.Bindings.AndroidFlipView;
    using NativeCode.Mobile.Core.XamarinForms.Droid.Renderers.Adapters;

    using Xamarin.Forms.Platform.Android;

    using FlipView = NativeCode.Mobile.Core.XamarinForms.Controls.FlipView;
    using NativeFlipView = NativeCode.Bindings.AndroidFlipView.FlipView;
    using Resource = NativeCode.Mobile.Core.XamarinForms.Droid.Resource;

    public class FlipViewRenderer : InflateViewRenderer<FlipView, NativeFlipView>, NativeFlipView.IOnFlipListener, NativeFlipView.IOnOverFlipListener, IFlipAdapterCallback
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
                this.FlipAdapter = new FlipAdapter(this);

                var control = this.InflateNativeControl(Resource.Layout.flipview);
                control.SetOnFlipListener(this);
                control.SetOnOverFlipListener(this);

                this.SetNativeControl(control);
                this.UpdateFlipAdapter();
                control.PeakNext(true);
            }
        }

        private void UpdateFlipAdapter()
        {
            foreach (var view in this.Element.Views)
            {
                var renderer = Droid.Extensions.ViewExtensions.GetRenderer(view);
                this.FlipAdapter.AddView(renderer.ViewGroup);
            }

            this.Control.Adapter = this.FlipAdapter;
            this.UpdateLayout();
        }
    }
}