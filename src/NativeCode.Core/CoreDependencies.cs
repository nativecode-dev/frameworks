namespace NativeCode.Core
{
    using NativeCode.Core.Dependencies;
    using NativeCode.Core.Localization;
    using NativeCode.Core.Logging;
    using NativeCode.Core.Serialization;

    public class CoreDependencies : IDependencyModule
    {
        private static readonly IDependencyModule DefaultInstance = new CoreDependencies();

        public static IDependencyModule Instance
        {
            get { return DefaultInstance; }
        }

        public void RegisterDependencies(IDependencyRegistrar registrar)
        {
            registrar.Register<ILogger, Logger>(lifetime: DependencyLifetime.PerApplication);
            registrar.Register<IStringSerializer, JsonStringSerializer>();
            registrar.Register<ITranslationProvider, DefaultTranslationProvider>();
            registrar.Register<ITranslator, Translator>();
        }
    }
}