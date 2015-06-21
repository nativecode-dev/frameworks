namespace Demo.Views
{
    using Demo.ViewModels;

    using Xamarin.Forms;

    public partial class MasterDetailOuterNavigationView : MasterDetailPage
    {
        public MasterDetailOuterNavigationView()
        {
            this.InitializeComponent();
        }

        protected MasterDetailOuterNavigationViewModel ViewModel
        {
            get { return (MasterDetailOuterNavigationViewModel)this.BindingContext; }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            this.Detail = this.ViewModel.DetailView;
            this.Master = this.ViewModel.MasterView;
        }
    }
}