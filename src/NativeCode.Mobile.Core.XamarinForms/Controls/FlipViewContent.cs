namespace NativeCode.Mobile.Core.XamarinForms.Controls
{
    using Xamarin.Forms;

    public class FlipViewContent : ContentView
    {
        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
        {
            if (this.Content == null)
            {
                return base.OnSizeRequest(100, 100);
            }

            return base.OnSizeRequest(this.Content.WidthRequest, this.Content.HeightRequest);
        }
    }
}