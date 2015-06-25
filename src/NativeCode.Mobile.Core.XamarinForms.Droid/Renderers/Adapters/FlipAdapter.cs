namespace NativeCode.Mobile.Core.XamarinForms.Droid.Renderers.Adapters
{
    using Android.Views;
    using Android.Widget;

    using NativeCode.Mobile.Core.XamarinForms.Controls;
    using NativeCode.Mobile.Core.XamarinForms.Droid.Extensions;

    using JavaObject = Java.Lang.Object;

    public class FlipAdapter : BaseAdapter<View>
    {
        private readonly IFlipViewContentProvider provider;

        public FlipAdapter(IFlipViewContentProvider provider)
        {
            this.provider = provider;
        }

        public override int Count
        {
            get { return this.provider.Count; }
        }

        public override View this[int position]
        {
            get
            {
                var content = this.provider.GetContent(position);
                return content.GetRenderer().ViewGroup;
            }
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