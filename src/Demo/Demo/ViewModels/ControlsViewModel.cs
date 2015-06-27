namespace Demo.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using NativeCode.Mobile.Core.Presentation;

    public class ControlsViewModel : NavigableViewModel
    {
        public ControlsViewModel()
        {
            this.Items =
                new ObservableCollection<ItemViewModel>(
                    new List<ItemViewModel>
                    {
                        new ItemViewModel { Text = "Source Item 0" },
                        new ItemViewModel { Text = "Source Item 1" },
                        new ItemViewModel { Text = "Source Item 2" },
                        new ItemViewModel { Text = "Source Item 3" },
                        new ItemViewModel { Text = "Source Item 4" },
                        new ItemViewModel { Text = "Source Item 5" },
                        new ItemViewModel { Text = "Source Item 6" },
                        new ItemViewModel { Text = "Source Item 7" },
                        new ItemViewModel { Text = "Source Item 8" },
                        new ItemViewModel { Text = "Source Item 9" }
                    });

            this.CurrentItem = this.Items[3];
        }

        public object CurrentItem { get; set; }

        public ObservableCollection<ItemViewModel> Items { get; private set; }

        public void OnCurrentItemChanged()
        {
            var current = this.CurrentItem;
            var index = this.Items.IndexOf((ItemViewModel)current);
            this.Title = "Selected index " + index;
        }

        public class ItemViewModel : ViewModel
        {
            public string Text { get; set; }

            public override string ToString()
            {
                return this.Text;
            }
        }
    }
}