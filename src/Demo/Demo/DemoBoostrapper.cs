namespace Demo
{
    using NativeCode.Mobile.Core;
    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.XamarinForms.Dependencies;

    public class DemoBoostrapper : Bootstrapper
    {
        private readonly FormsDependencyAdapter dependencyAdapter;

        public DemoBoostrapper()
        {
            this.dependencyAdapter = new FormsDependencyAdapter();
        }

        protected override void InternalInitialize()
        {
            DependencyResolver.SetResolver(() => this.dependencyAdapter);
        }
    }
}