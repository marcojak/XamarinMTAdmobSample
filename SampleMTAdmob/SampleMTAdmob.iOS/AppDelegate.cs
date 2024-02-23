﻿using Foundation;
using MarcTron.Plugin;
using MarcTron.Plugin.Extra;
using UIKit;

namespace SampleMTAdmob.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();

            string license = "wPoUz+iRtDjdJeAEifYnW8IZyoUuRrorUljh/1we2cN8LBsyQUL5cWezi3CRoSIG/THxiL1lsblsaKHgFxf+LgPmbhbBr14QdtBbbiVs6k3rwCs4NfzEtMozbW4xKPorYaD+YmrYupRZkNL1IdgbK4RqJn37lP5olfpdIVAIT4Y=|i94UXHKKoqNjtnV7GxmyWAo1xIApF2NUJSOUwVZx9IQ=";
            string deviceId = ""; //<--- Your test device id here
            string OPENADS_AD_UNIT_ID = "ca-app-pub-3940256099942544/5575463023";

            CrossMTAdmob.Current.Init(license, OPENADS_AD_UNIT_ID, true, false, deviceId, DebugGeography.DEBUG_GEOGRAPHY_EEA);

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public override void OnActivated(UIApplication application)
        {
            base.OnActivated(application);
            CrossMTAdmob.Current.OnResume();
        }
    }
}
