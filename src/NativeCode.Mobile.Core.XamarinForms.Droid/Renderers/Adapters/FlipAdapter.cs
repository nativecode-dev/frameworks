namespace NativeCode.Mobile.Core.XamarinForms.Droid.Renderers.Adapters
{
    using System.Collections.Generic;

    using Android.Views;
    using Android.Widget;

    using JavaObject = Java.Lang.Object;

    public class FlipAdapter : BaseAdapter<View>, View.IOnClickListener
    {
        private readonly List<View> views = new List<View>();

        private readonly IFlipAdapterCallback callback;

        public FlipAdapter(IFlipAdapterCallback callback)
        {
            this.callback = callback;
        }

        public override int Count
        {
            get { return this.views.Count; }
        }

        public override View this[int position]
        {
            get { return this.views[position]; }
        }

        public virtual void AddView(View view)
        {
            this.views.Add(view);
            this.NotifyDataSetChanged();
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

        public void OnClick(View view)
        {
            this.callback.OnPageRequested(this.views.IndexOf(view));
        }
    }
}