using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Acr.UserDialogs;
using FFImageLoading.Forms.Droid;
using Plugin.Permissions;

namespace Treinus.App.Droid
{
    [Activity(Label = "Treinus", Icon = "@drawable/logo", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Xamarin.FormsMaps.Init(this, bundle);
            ImageCircleRenderer.Init();
            CachedImageRenderer.Init(null);
            UserDialogs.Init(this);

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults) =>
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }
}