namespace NativeCode.Mobile.Core
{
    using NativeCode.Core.Dependencies;
    using NativeCode.Mobile.Core.Processing;

    public class CoreMobileDependencies : IDependencyModule
    {
        private static readonly IDependencyModule DefaultInstance = new CoreMobileDependencies();

        public static IDependencyModule Instance
        {
            get
            {
                return DefaultInstance;
            }
        }

        public void RegisterDependencies(IDependencyRegistrar registrar)
        {
            registrar.Register<IQueueProcessorFactory, QueueProcessorFactory>();
        }
    }
}