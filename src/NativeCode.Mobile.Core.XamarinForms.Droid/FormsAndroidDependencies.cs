namespace NativeCode.Mobile.Core.XamarinForms.Droid
{
    using NativeCode.Core.Dependencies;
    using NativeCode.Mobile.Core.Droid.Platform;
    using NativeCode.Mobile.Core.XamarinForms.Droid.Platform;
    using NativeCode.Mobile.Core.XamarinForms.Platform;

    public class FormsAndroidDependencies : IDependencyModule
    {
        private static readonly IDependencyModule DefaultInstance = new FormsAndroidDependencies();

        public static IDependencyModule Instance
        {
            get { return DefaultInstance; }
        }

        public void RegisterDependencies(IDependencyRegistrar registrar)
        {
            registrar.Register<IContextProvider, FormsContextProvider>();
            registrar.Register<IMobileInformant, MobileInformant>();
        }
    }
}