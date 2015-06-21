namespace NativeCode.Mobile.Core.XamarinForms
{
    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.Presentation;
    using NativeCode.Mobile.Core.XamarinForms.Presentation;

    public class XamarinFormsDependencies : IDependencyModule
    {
        public void RegisterDependencies(IDependencyRegistrar registrar)
        {
            registrar.Register<IPresentationFactory, PresentationFactory>();
            registrar.Register<IViewModelNavigatorProvider, ViewModelNavigatorProvider>();
        }
    }
}