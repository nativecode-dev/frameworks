namespace NativeCode.Mobile.Core.XamarinForms.Controls
{
    using System.Collections.Generic;

    using Xamarin.Forms;

    [ContentProperty("Views")]
    public class FlipView : View
    {
        public static readonly BindableProperty FlipViewStyleProperty = BindableProperty.Create<FlipView, FlipViewStyle>(
            x => x.FlipViewStyle,
            default(FlipViewStyle));

        public static readonly BindableProperty ViewsProperty = BindableProperty.Create<FlipView, IList<View>>(x => x.Views, new List<View>());

        public FlipViewStyle FlipViewStyle
        {
            get { return (FlipViewStyle)this.GetValue(FlipViewStyleProperty); }
            set { this.SetValue(FlipViewStyleProperty, value); }
        }

        public IList<View> Views
        {
            get { return (IList<View>)this.GetValue(ViewsProperty); }
            set { this.SetValue(ViewsProperty, value); }
        }
    }
}