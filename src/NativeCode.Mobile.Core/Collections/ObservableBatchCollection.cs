namespace NativeCode.Mobile.Core.Collections
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;

    public class ObservableBatchCollection<T> : ObservableCollection<T>
    {
        private const string CountName = "Count";

        private const string IndexerName = "Item[]";

        public ObservableBatchCollection()
        {
        }

        public ObservableBatchCollection(IEnumerable<T> collection) : base(collection)
        {
        }

        public virtual void AddRange(IEnumerable<T> range)
        {
            using (this.BlockReentrancy())
            {
                foreach (var item in range)
                {
                    this.Items.Add(item);
                }

                this.OnPropertyChanged(CountName);
                this.OnPropertyChanged(IndexerName);
                this.OnCollectionReset();
            }
        }

        public void Reset()
        {
            this.Reset(Enumerable.Empty<T>());
        }

        public void Reset(IEnumerable<T> range)
        {
            this.ClearItems();
            this.AddRange(range);
        }

        private void OnCollectionReset()
        {
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void OnPropertyChanged(string property)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(property));
        }
    }
}