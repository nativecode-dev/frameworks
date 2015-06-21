namespace NativeCode.Mobile.Core.XamarinForms.Droid
{
    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.Droid.Platform;
    using NativeCode.Mobile.Core.XamarinForms.Droid.Platform;

    public class FormsAndroidDependencies : IDependencyModule
    {
        public void RegisterDependencies(IDependencyRegistrar registrar)
        {
            registrar.Register<IContextProvider, FormsContextProvider>();
        }
    }
}