namespace NativeCode.Core
{
    using System;

    public class EventArgs<T> : EventArgs
    {
        public EventArgs()
        {
        }

        public EventArgs(T item)
        {
            this.Item = item;
        }

        public T Item { get; private set; }
    }
}