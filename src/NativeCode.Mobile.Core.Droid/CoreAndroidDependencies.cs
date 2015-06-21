namespace NativeCode.Mobile.Core.Droid
{
    using NativeCode.Mobile.Core.Collections;
    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.Droid.Collections;
    using NativeCode.Mobile.Core.Droid.Platform;
    using NativeCode.Mobile.Core.Platform;

    public class CoreAndroidDependencies : IDependencyModule
    {
        public void RegisterDependencies(IDependencyRegistrar registrar)
        {
            registrar.Register<ICollectionFactory, CollectionFactory>();
            registrar.Register<IDeviceInformant, DeviceInformant>();
        }
    }
}