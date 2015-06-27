namespace NativeCode.Mobile.Core.XamarinForms.Controls
{
    using System.Collections;

    using Xamarin.Forms;

    public class SpinSelector : View
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create<SpinSelector, IList>(x => x.ItemsSource, default(IList));

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create<SpinSelector, object>(x => x.SelectedItem, default(object));

        public static readonly BindableProperty SelectorStyleProperty = BindableProperty.Create<SpinSelector, SpinSelectorStyle>(
            x => x.SelectorStyle,
            default(SpinSelectorStyle));

        public IList ItemsSource
        {
            get { return (IList)this.GetValue(ItemsSourceProperty); }
            set { this.SetValue(ItemsSourceProperty, value); }
        }

        public SpinSelectorStyle SelectorStyle
        {
            get { return (SpinSelectorStyle)this.GetValue(SelectorStyleProperty); }
            set { this.SetValue(SelectorStyleProperty, value); }
        }

        public object SelectedItem
        {
            get { return this.GetValue(SelectedItemProperty); }
            set { this.SetValue(SelectedItemProperty, value); }
        }

        public int GetSelectedIndex(object item)
        {
            return this.ItemsSource.IndexOf(item);
        }
    }
}