namespace NativeCode.Mobile.Core.XamarinForms.Presentation
{
    using System;
    using System.Collections.Generic;

    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.Presentation;

    using Xamarin.Forms;

    public static class PresentationFactoryRegistry
    {
        private static readonly Dictionary<string, Registration> Registrations = new Dictionary<string, Registration>();

        public static void Register<TView, TViewModel>(IDependencyRegistrar registrar) where TView : Page where TViewModel : ViewModel
        {
            var key = typeof(TViewModel).AssemblyQualifiedName;

            if (Registrations.ContainsKey(key))
            {
                return;
            }

            Registrations.Add(key, new Registration(typeof(TView), typeof(TViewModel)));

            registrar.Register<TView>();
            registrar.Register<TViewModel>();
        }

        public static Registration GetRegistration<TViewModel>() where TViewModel : ViewModel
        {
            var key = typeof(TViewModel).AssemblyQualifiedName;

            if (Registrations.ContainsKey(key))
            {
                return Registrations[key];
            }

            throw new ViewModelTypeNotFoundException(typeof(TViewModel));
        }

        public class Registration
        {
            internal Registration(Type view, Type viewModel)
            {
                this.View = view;
                this.ViewModel = viewModel;
            }

            public Type View { get; private set; }

            public Type ViewModel { get; private set; }
        }
    }
}