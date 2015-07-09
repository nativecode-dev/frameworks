using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace NativeCode.Core.Collections
{
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
                var additions = new List<T>();

                foreach (var item in range)
                {
                    this.Items.Add(item);
                    additions.Add(item);
                }

                this.OnPropertyChanged(CountName);
                this.OnPropertyChanged(IndexerName);
                this.OnCollectionChanged(this.CreateAddArgs(additions));
            }
        }

        public virtual void Reset()
        {
            this.Reset(Enumerable.Empty<T>());
        }

        public virtual void Reset(IEnumerable<T> range)
        {
            this.ClearItems();
            this.AddRange(range);
        }

        protected virtual void OnPropertyChanged(string property)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(property));
        }

        protected virtual NotifyCollectionChangedEventArgs CreateAddArgs(IList additions)
        {
            return new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, additions);
        }

        protected virtual NotifyCollectionChangedEventArgs CreateRemoveArgs(IList removals)
        {
            return new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removals);
        }

        protected virtual NotifyCollectionChangedEventArgs CreateResetArgs()
        {
            return new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
        }
    }
}