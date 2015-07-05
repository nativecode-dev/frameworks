using NativeCode.Mobile.Core.XamarinForms.Controls;
using NativeCode.Mobile.Core.XamarinForms.Droid.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SpinSelector), typeof(SpinSelectorRenderer))]

namespace NativeCode.Mobile.Core.XamarinForms.Droid.Renderers
{
    using System.Collections.Specialized;
    using System.ComponentModel;

    using Android.Support.V7.Widget;
    using Android.Views;
    using Android.Widget;

    using NativeCode.Mobile.Core.XamarinForms.Controls;

    using Xamarin.Forms.Platform.Android;

    using Resource = NativeCode.Mobile.Core.XamarinForms.Droid.Resource;

    public class SpinSelectorRenderer : InflateViewRenderer<SpinSelector, AppCompatSpinner>, AdapterView.IOnItemSelectedListener
    {
        protected ArrayAdapter<object> Adapter { get; private set; }

        protected INotifyCollectionChanged ObservableCollection { get; private set; }

        public void OnItemSelected(AdapterView parent, View view, int position, long id)
        {
            var item = this.Element.ItemsSource[position];

            if (this.Element.SelectedItem != item)
            {
                ((IElementController)this.Element).SetValueFromRenderer(SpinSelector.SelectedItemProperty, item);
            }
        }

        public void OnNothingSelected(AdapterView parent)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SpinSelector> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                var control = this.CreateAppCompatSpinner();
                control.Adapter = this.Adapter = new ArrayAdapter<object>(this.Context, Android.Resource.Layout.SimpleListItemActivated1);
                control.OnItemSelectedListener = this;

                this.SetNativeControl(control);

                this.UpdateItemsSource();
                this.UpdateSelectedItem();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == SpinSelector.ItemsSourceProperty.PropertyName)
            {
                this.UpdateItemsSource();
            }
            else if (e.PropertyName == SpinSelector.SelectedItemProperty.PropertyName)
            {
                this.UpdateSelectedItem();
            }
        }

        private AppCompatSpinner CreateAppCompatSpinner()
        {
            if (this.Element.SelectorStyle == SpinSelectorStyle.DropDown)
            {
                return this.InflateNativeControl<AppCompatSpinner>(Resource.Layout.spinner_dropdown);
            }

            return this.InflateNativeControl<AppCompatSpinner>(Resource.Layout.spinner_dialog);
        }

        private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    this.Adapter.Add(item);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    this.Adapter.Remove(item);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                this.Adapter.Clear();
            }
        }

        private void UpdateItemsSource()
        {
            this.UnhookObservableCollection();
            this.Adapter.Clear();

            if (this.Element.ItemsSource == null)
            {
                return;
            }

            foreach (var item in this.Element.ItemsSource)
            {
                this.Adapter.Add(item);
            }

            this.HookObservableCollection();
        }

        private void UpdateSelectedItem()
        {
            var index = this.Element.GetSelectedIndex(this.Element.SelectedItem);

            if (index != this.Control.SelectedItemPosition)
            {
                this.Control.SetSelection(index);
            }
        }

        private void HookObservableCollection()
        {
            this.ObservableCollection = this.Element.ItemsSource as INotifyCollectionChanged;

            if (this.ObservableCollection != null)
            {
                this.ObservableCollection.CollectionChanged += this.HandleCollectionChanged;
            }
        }

        private void UnhookObservableCollection()
        {
            if (this.ObservableCollection != null)
            {
                this.ObservableCollection.CollectionChanged -= this.HandleCollectionChanged;
                this.ObservableCollection = null;
            }
        }
    }
}