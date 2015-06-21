﻿namespace Demo.Droid
{
    using System.Collections.Generic;

    using Android.App;
    using Android.OS;

    using NativeCode.Mobile.AppCompat.FormsAppCompat;
    using NativeCode.Mobile.AppCompat.Renderers;
    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.Droid;

    using Xamarin.Forms;

    [Activity(MainLauncher = true, Theme = CompatThemeLightDarkActionBar)]
    public class MainActivity : AppCompatFormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            FormsAppCompat.EnableAll();

            this.LoadApplication(new App(this.CreateDependencyModules()));
        }

        private IEnumerable<IDependencyModule> CreateDependencyModules()
        {
            return new IDependencyModule[] { new CoreAndroidDependencies() };
        }
    }
}