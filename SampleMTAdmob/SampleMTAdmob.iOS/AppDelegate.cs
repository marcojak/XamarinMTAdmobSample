using Foundation;
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

            string license = "EwfjsC2Bqf5Y7c88KhSJeZTQzdSoWY8uYEByS2y/5PxsMCciZCyLPBl7NDwtrHJNQ2H34H7r2IpoSrZZc0SckO2xn3ZFrgyx";
            string testDeviceId = ""; //<--- Your test device id here
            string OPENADS_AD_UNIT_ID = "ca-app-pub-3940256099942544/5575463023";
            bool enableOpenAds = false;
            bool tagForUnderAgeconsent = false;
            bool initialiseConsentAtStartup = false;

            CrossMTAdmob.Current.Init(license, OPENADS_AD_UNIT_ID, enableOpenAds, tagForUnderAgeconsent, testDeviceId, DebugGeography.DEBUG_GEOGRAPHY_EEA, initialiseConsentAtStartup);

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
