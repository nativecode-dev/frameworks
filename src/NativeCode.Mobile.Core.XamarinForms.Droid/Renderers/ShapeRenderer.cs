using NativeCode.Mobile.Core.XamarinForms.Controls;
using NativeCode.Mobile.Core.XamarinForms.Droid.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Shape), typeof(ShapeRenderer))]

namespace NativeCode.Mobile.Core.XamarinForms.Droid.Renderers
{
    using Android.Graphics;
    using Android.Graphics.Drawables;
    using Android.Graphics.Drawables.Shapes;
    using Android.Views;
    using Android.Widget;

    using Xamarin.Forms.Platform.Android;

    using Color = Xamarin.Forms.Color;
    using Shape = NativeCode.Mobile.Core.XamarinForms.Controls.Shape;

    public class ShapeRenderer : ViewRenderer<Shape, ImageView>
    {
        protected override bool DrawChild(Canvas canvas, View child, long drawingTime)
        {
            var shape = new ShapeDrawable(new OvalShape());
            shape.SetIntrinsicHeight(64);
            shape.SetIntrinsicWidth(64);
            shape.Paint.Color = Color.Black.ToAndroid();
            shape.Draw(canvas);

            return base.DrawChild(canvas, child, drawingTime);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Shape> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                var control = new ImageView(this.Context);
                this.SetNativeControl(control);
                this.Control.RefreshDrawableState();
            }
        }
    }
}