﻿using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using MarcTron.Plugin;
using MarcTron.Plugin.Extra;

namespace SampleMTAdmob.Droid
{
    [Activity(Label = "SampleMTAdmob", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            string license = "EwfjsC2Bqf5Y7c88KhSJeZTQzdSoWY8uYEByS2y/5PxsMCciZCyLPBl7NDwtrHJNQ2H34H7r2IpoSrZZc0SckO2xn3ZFrgyx";
            string OPENADS_AD_UNIT_ID = "ca-app-pub-3940256099942544/9257395921";
            string NATIVEADS_AD_UNIT_ID = "ca-app-pub-3940256099942544/2247696110";

            bool initialiseConsentAtStartup = true;

            CrossMTAdmob.Current.Init(this, "ca-app-pub-3940256099942544~3347511713", license, /*NATIVEADS_AD_UNIT_ID,*/ OPENADS_AD_UNIT_ID, true, false, "C44999673C1A6EDCE0DA791B8E5436C1", true, DebugGeography.DEBUG_GEOGRAPHY_EEA, initialiseConsentAtStartup);

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnResume()
        {
            base.OnResume();
            CrossMTAdmob.Current.OnResume();
        }
    }
}