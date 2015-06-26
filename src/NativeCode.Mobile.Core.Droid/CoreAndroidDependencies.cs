namespace NativeCode.Mobile.Core.Droid
{
    using NativeCode.Mobile.Core.Collections;
    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.Droid.Collections;
    using NativeCode.Mobile.Core.Droid.Logging;
    using NativeCode.Mobile.Core.Droid.Platform;
    using NativeCode.Mobile.Core.Logging;
    using NativeCode.Mobile.Core.Platform;

    public class CoreAndroidDependencies : IDependencyModule
    {
        private static readonly IDependencyModule DefaultInstance = new CoreAndroidDependencies();

        public static IDependencyModule Instance
        {
            get { return DefaultInstance; }
        }

        public void RegisterDependencies(IDependencyRegistrar registrar)
        {
            registrar.Register<ICollectionFactory, CollectionFactory>();
            registrar.Register<IDeviceInformant, DeviceInformant>();
            registrar.RegisterAll<ILogWriter>(typeof(LogcatLogWriter));
        }
    }
}