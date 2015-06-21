namespace NativeCode.Mobile.Core.XamarinForms.Dependencies
{
    using System;
    using System.Collections.Generic;

    using NativeCode.Mobile.Core.Dependencies;

    using Xamarin.Forms;

    public class FormsDependencyAdapter : DependencyAdapter
    {
        public override void Factory(Type contract, Func<IDependencyResolver, object> factory)
        {
            throw new NotSupportedException();
        }

        public override void Factory<TContract>(Func<IDependencyResolver, TContract> factory)
        {
            throw new NotSupportedException();
        }

        public override void Register(Type contract, string key, DependencyLifetime lifetime = DependencyLifetime.Default)
        {
            throw new NotSupportedException();
        }

        public override void Register(Type contract, Type implementation, string key, DependencyLifetime lifetime = DependencyLifetime.Default)
        {
            throw new NotSupportedException();
        }

        public override void Register<TContract>(DependencyKey key = DependencyKey.None, DependencyLifetime lifetime = DependencyLifetime.Default)
        {
            DependencyService.Register<TContract>();
        }

        public override void Register<TContract>(string key, DependencyLifetime lifetime = DependencyLifetime.Default)
        {
            DependencyService.Register<TContract>();
        }

        public override void Register<TContract, TImplementation>(
            DependencyKey key = DependencyKey.None,
            DependencyLifetime lifetime = DependencyLifetime.Default)
        {
            DependencyService.Register<TContract, TImplementation>();
        }

        public override void Register<TContract, TImplementation>(string key, DependencyLifetime lifetime = DependencyLifetime.Default)
        {
            DependencyService.Register<TContract, TImplementation>();
        }

        public override object Resolve(Type type, string key = null)
        {
            throw new NotSupportedException();
        }

        public override object Resolve(Type type, DependencyKey key)
        {
            throw new NotSupportedException();
        }

        public override T Resolve<T>(string key = null)
        {
            return DependencyService.Get<T>();
        }

        public override T Resolve<T>(DependencyKey key)
        {
            return DependencyService.Get<T>();
        }

        public override IEnumerable<object> ResolveAll(Type type)
        {
            throw new NotSupportedException();
        }

        public override IEnumerable<T> ResolveAll<T>()
        {
            return DependencyService.Get<IEnumerable<T>>();
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}