namespace NativeCode.Mobile.Core
{
    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.Localization;
    using NativeCode.Mobile.Core.Processing;
    using NativeCode.Mobile.Core.Serialization;

    public class CoreDependencies : IDependencyModule
    {
        public void RegisterDependencies(IDependencyRegistrar registrar)
        {
            registrar.Register<IQueueProcessorFactory, QueueProcessorFactory>();
            registrar.Register<IStringSerializer, JsonStringSerializer>();
            registrar.Register<ITranslationProvider, DefaultTranslationProvider>();
        }
    }
}