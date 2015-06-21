namespace Demo.Views
{
    using Demo.ViewModels;

    using Xamarin.Forms;

    public partial class SimpleMasterDetailView : MasterDetailPage
    {
        public SimpleMasterDetailView()
        {
            this.InitializeComponent();
        }

        protected SimpleMasterDetailViewModel ViewModel
        {
            get { return (SimpleMasterDetailViewModel)this.BindingContext; }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            this.Detail = this.ViewModel.DetailView;
            this.Master = this.ViewModel.MasterView;
        }
    }
}