namespace Demo.Views
{
    using Demo.ViewModels;

    using NativeCode.Mobile.Core.XamarinForms.Controls;

    public partial class WebContentView : FlipViewContent
    {
        public WebContentView()
        {
            this.InitializeComponent();
        }

        public WebContentView(WebContentViewModel viewModel) : this()
        {
            this.BindingContext = viewModel;
        }
    }
}