namespace Demo.ViewModels
{
    using NativeCode.Mobile.Core.Presentation;
    using NativeCode.Mobile.Core.XamarinForms.Extensions;
    using NativeCode.Mobile.Core.XamarinForms.Presentation;

    using Xamarin.Forms;

    public class MasterDetailInnerNavigationViewModel : NavigableViewModel
    {
        public MasterDetailInnerNavigationViewModel(IPresentationFactory presentationFactory)
        {
            if (Device.Idiom == TargetIdiom.Phone)
            {
                this.MasterBehavior = MasterBehavior.Popover;
            }

            this.DetailView = presentationFactory.GetViewFor<ArticleViewModel>().WithNavigation();
            this.MasterView = presentationFactory.GetViewFor<SimpleNavigationViewModel>();
        }

        public Page DetailView { get; set; }

        public MasterBehavior MasterBehavior { get; set; }

        public Page MasterView { get; set; }
    }
}