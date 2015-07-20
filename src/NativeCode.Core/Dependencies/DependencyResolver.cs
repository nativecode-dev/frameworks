namespace NativeCode.Core.Dependencies
{
    using System;

    public static class DependencyResolver
    {
        public static IDependencyResolver Current
        {
            get
            {
                EnsureLocatorSet();
                return Resolver();
            }
        }

        private static Func<IDependencyResolver> Resolver { get; set; }

        public static void SetResolver(Func<IDependencyResolver> resolver)
        {
            Resolver = resolver;
        }

        private static void EnsureLocatorSet()
        {
            if (Resolver == null)
            {
                throw new InvalidOperationException("Locator was not set.");
            }
        }
    }
}