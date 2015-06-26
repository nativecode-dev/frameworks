namespace NativeCode.Mobile.Core.XamarinForms.Droid.Renderers.Adapters
{
    using Android.Views;
    using Android.Widget;

    using NativeCode.Mobile.Core.XamarinForms.Controls;
    using NativeCode.Mobile.Core.XamarinForms.Controls.ContentProviders;
    using NativeCode.Mobile.Core.XamarinForms.Droid.Extensions;

    using JavaObject = Java.Lang.Object;

    public class FlipAdapter : BaseAdapter<View>
    {
        private readonly IContentViewProvider<FlipViewContent> provider;

        public FlipAdapter(IContentViewProvider<FlipViewContent> provider)
        {
            this.provider = provider;
        }

        public override int Count
        {
            get { return this.provider.Count; }
        }

        public override bool HasStableIds
        {
            get { return true; }
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
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            return this[position];
        }

        public void Invalidate()
        {
            this.NotifyDataSetChanged();
        }
    }
}