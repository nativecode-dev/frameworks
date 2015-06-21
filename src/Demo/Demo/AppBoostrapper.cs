namespace Demo
{
    using System.Collections.Generic;

    using NativeCode.Mobile.Core;
    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.XamarinForms.Dependencies;

    internal class AppBoostrapper : Bootstrapper
    {
        private readonly FormsDependencyAdapter dependencyAdapter;

        public AppBoostrapper(IEnumerable<IDependencyModule> modules)
        {
            this.dependencyAdapter = new FormsDependencyAdapter(modules);
        }

        protected override void InternalInitialize()
        {
            DependencyResolver.SetResolver(() => this.dependencyAdapter);
        }
    }
}