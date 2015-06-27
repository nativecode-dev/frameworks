namespace NativeCode.Mobile.Core.XamarinForms.Dependencies
{
    using System;
    using System.Collections.Generic;

    using NativeCode.Mobile.Core.Dependencies;

    using SimpleInjector;

    public class FormsDependencyAdapter : DependencyAdapter
    {
        private readonly Container container;

        public FormsDependencyAdapter()
        {
            this.container = new Container();
            this.container.Options.AllowOverridingRegistrations = true;
        }

        public override void Factory(Type contract, Func<IDependencyResolver, object> factory)
        {
            this.container.Register(() => factory(this));
        }

        public override void Factory<TContract>(Func<IDependencyResolver, TContract> factory)
        {
            this.container.Register(() => factory(this));
        }

        public override void Instance<TContract>(TContract instance)
        {
            this.container.RegisterSingle(instance);
        }

        public override void Register(Type contract, string key, DependencyLifetime lifetime = DependencyLifetime.Default)
        {
            if (lifetime == DependencyLifetime.PerApplication)
            {
                this.container.RegisterSingle(contract);
                return;
            }

            this.container.Register(contract);
        }

        public override void Register(Type contract, Type implementation, string key, DependencyLifetime lifetime = DependencyLifetime.Default)
        {
            this.container.Register(contract, implementation, CreateLifestyle(lifetime));
        }

        public override void RegisterAll<TContract>(IEnumerable<Type> implementations)
        {
            this.container.RegisterAll<TContract>(implementations);
        }

        public override object Resolve(Type type, string key = null)
        {
            return this.container.GetInstance(type);
        }

        public override object Resolve(Type type, DependencyKey key)
        {
            return this.container.GetInstance(type);
        }

        public override T Resolve<T>(string key = null)
        {
            return this.container.GetInstance<T>();
        }

        public override T Resolve<T>(DependencyKey key)
        {
            return this.container.GetInstance<T>();
        }

        public override IEnumerable<object> ResolveAll(Type type)
        {
            return this.container.GetAllInstances(type);
        }

        public override IEnumerable<T> ResolveAll<T>()
        {
            return this.container.GetAllInstances<T>();
        }

        protected override void Dispose(bool disposing)
        {
        }

        private static Lifestyle CreateLifestyle(DependencyLifetime lifetime)
        {
            switch (lifetime)
            {
                case DependencyLifetime.PerApplication:
                    return Lifestyle.Singleton;

                default:
                    return Lifestyle.Transient;
            }
        }
    }
}