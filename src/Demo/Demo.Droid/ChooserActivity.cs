namespace Demo.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.OS;

    [Activity(ConfigurationChanges = ActivityConfig, MainLauncher = false, Theme = "@style/Theme.AppCompat.NoActionBar")]
    public class ChooserActivity : Activity
    {
        private const ConfigChanges ActivityConfig = ConfigChanges.Orientation | ConfigChanges.ScreenSize;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var inflated = this.LayoutInflater.Inflate(Resource.Layout.chooser, null, false);
            this.SetContentView(inflated);
        }
    }
}