using Android.App;
using Android.OS;
using Java.Lang;
using MonkeySpace;

namespace AzureConf.Activities
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true, Label = "WAC2014", Icon = "@drawable/icon")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Thread.Sleep(2000); // Simulate a long loading process on app startup.
            StartActivity(typeof(SessionsActivity));
        }
    }
}