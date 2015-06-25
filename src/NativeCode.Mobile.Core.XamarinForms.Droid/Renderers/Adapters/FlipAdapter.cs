namespace NativeCode.Mobile.Core.XamarinForms.Droid.Renderers.Adapters
{
    using Android.Views;
    using Android.Widget;

    using NativeCode.Mobile.Core.XamarinForms.Controls;
    using NativeCode.Mobile.Core.XamarinForms.Droid.Extensions;

    using JavaObject = Java.Lang.Object;

    public class FlipAdapter : BaseAdapter<View>
    {
        private readonly FlipView flipView;

        public FlipAdapter(FlipView flipView)
        {
            this.flipView = flipView;
        }

        public override int Count
        {
            get { return this.flipView.Views.Count; }
        }

        public override View this[int position]
        {
            get { return ViewExtensions.GetRenderer(this.flipView.Views[position]).ViewGroup; }
        }

        public override JavaObject GetItem(int position)
        {
            return this[position];
        }

        public override long GetItemId(int position)
        {
            return this[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            return this[position];
        }
    }
}