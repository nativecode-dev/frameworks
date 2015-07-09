namespace NativeCode.Mobile.Core.Droid
{
    using NativeCode.Core.Dependencies;
    using NativeCode.Core.Logging;
    using NativeCode.Mobile.Core.Collections;
    using NativeCode.Mobile.Core.Droid.Collections;
    using NativeCode.Mobile.Core.Droid.Logging;
    using NativeCode.Mobile.Core.Droid.Platform;
    using NativeCode.Mobile.Core.Droid.Platform.Storage;
    using NativeCode.Mobile.Core.Platform;

    public class CoreAndroidDependencies : IDependencyModule
    {
        private static readonly IDependencyModule DefaultInstance = new CoreAndroidDependencies();

        public static IDependencyModule Instance
        {
            get
            {
                return DefaultInstance;
            }
        }

        public void RegisterDependencies(IDependencyRegistrar registrar)
        {
            registrar.Register<ICollectionFactory, CollectionFactory>();
            registrar.Register<IDeviceInformant, DeviceInformant>();
            registrar.Register<IStorageProvider, StorageProvider>();

            registrar.RegisterAll<ILogWriter>(typeof(LogcatLogWriter));
        }
    }
}