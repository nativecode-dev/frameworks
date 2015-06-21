namespace Demo.Views
{
    using Demo.ViewModels;

    using Xamarin.Forms;

    public partial class MasterDetailInnerNavigationView : MasterDetailPage
    {
        public MasterDetailInnerNavigationView()
        {
            this.InitializeComponent();
        }

        protected MasterDetailInnerNavigationViewModel ViewModel
        {
            get { return (MasterDetailInnerNavigationViewModel)this.BindingContext; }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            this.Detail = this.ViewModel.DetailView;
            this.Master = this.ViewModel.MasterView;
        }
    }
}