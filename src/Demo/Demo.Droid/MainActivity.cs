namespace Demo.Droid
{
    using Android.App;
    using Android.OS;

    using NativeCode.Mobile.AppCompat.FormsAppCompat;
    using NativeCode.Mobile.AppCompat.Renderers;

    using Xamarin.Forms;

    [Activity(MainLauncher = true, Theme = CompatThemeLightDarkActionBar)]
    public class MainActivity : AppCompatFormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            FormsAppCompat.EnableAll();

            this.LoadApplication(new App());
        }
    }
}