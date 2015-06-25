namespace NativeCode.Mobile.Core.XamarinForms.Controls
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class FlipViewContentProvider<T> : IFlipViewContentProvider
    {
        private readonly IEnumerable<T> enumerable;

        private readonly List<FlipViewContent> cache = new List<FlipViewContent>();

        protected FlipViewContentProvider(IEnumerable<T> enumerable)
        {
            this.enumerable = enumerable;
        }

        public int Count
        {
            get { return this.enumerable.Count(); }
        }

        protected IReadOnlyList<FlipViewContent> Cache
        {
            get { return this.cache; }
        }

        public FlipViewContent GetContent(int position)
        {
            var count = this.Cache.Count - 1;

            if (position <= count)
            {
                return this.Cache[position];
            }

            var content = this.CreateFlipViewContent(position);
            this.cache.Add(content);

            return content;
        }

        protected abstract FlipViewContent CreateFlipViewContent(int position);

        protected T GetContentItem(int position)
        {
            return this.enumerable.ElementAt(position);
        }
    }
}