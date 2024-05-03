using System;
using System.ComponentModel;
using System.Diagnostics;
using MarcTron.Plugin;
using Xamarin.Forms;
using MarcTron.Plugin.Extra;

namespace SampleMTAdmob
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private bool _shouldSetEvents = true;
        public MainPage()
        {
            InitializeComponent();
            CrossMTAdmob.Current.TagForChildDirectedTreatment = MTTagForChildDirectedTreatment.TagForChildDirectedTreatmentUnspecified;
            CrossMTAdmob.Current.TagForUnderAgeOfConsent = MTTagForUnderAgeOfConsent.TagForUnderAgeOfConsentUnspecified;
            CrossMTAdmob.Current.MaxAdContentRating = MTMaxAdContentRating.MaxAdContentRatingG;

            if (CrossMTAdmob.Current.IsLicensed)
                LabelLicense.Text = "Licensed";
            //If you want to load a banner programmatically:
            //MTAdView myAds = new MTAdView();
            //myAds.AdsId = "xxx";
            //myAds.PersonalizedAds = true;
            //myAds.AdsClicked += MyAds_AdsClicked;
            //myAds.AdsClosed += MyAds_AdVClosed;
            //myAds.AdsImpression += MyAds_AdVImpression;
            //myAds.AdsOpened += MyAds_AdVOpened;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetEvents();
        }

        void SetEvents()
        {
            if (_shouldSetEvents)
            {
                _shouldSetEvents = false;
                CrossMTAdmob.Current.OnUserEarnedReward += Current_OnRewarded;

                CrossMTAdmob.Current.OnRewardedClosed += Current_OnRewardedVideoAdClosed;
                CrossMTAdmob.Current.OnRewardedFailedToLoad += Current_OnRewardedVideoAdFailedToLoad;
                CrossMTAdmob.Current.OnRewardedFailedToShow += Current_OnRewardedFailedToShow;
                CrossMTAdmob.Current.OnRewardedLoaded += Current_OnRewardedVideoAdLoaded;
                CrossMTAdmob.Current.OnRewardedOpened += Current_OnRewardedVideoAdOpened;
                CrossMTAdmob.Current.OnRewardedImpression += Current_OnRewardedImpression;
                CrossMTAdmob.Current.OnRewardedClicked += Current_OnRewardedClicked;

                CrossMTAdmob.Current.OnInterstitialLoaded += Current_OnInterstitialLoaded;
                CrossMTAdmob.Current.OnInterstitialFailedToLoad += Current_OnInterstitialFailedToLoad;
                CrossMTAdmob.Current.OnInterstitialOpened += Current_OnInterstitialOpened;
                CrossMTAdmob.Current.OnInterstitialFailedToShow += Current_OnInterstitialFailedToShow;
                CrossMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialClosed;
                CrossMTAdmob.Current.OnInterstitialClicked += Current_OnInterstitialClicked;
                CrossMTAdmob.Current.OnInterstitialImpression += Current_OnInterstitialImpression;

                CrossMTAdmob.Current.OnAppOpenAdLoaded += Current_OnAppOpenAdLoaded;
                CrossMTAdmob.Current.OnAppOpenOpened += Current_OnAppOpenOpened;
                CrossMTAdmob.Current.OnAppOpenClosed += Current_OnAppOpenClosed;
                CrossMTAdmob.Current.OnAppOpenFailedToLoad += Current_OnAppOpenFailedToLoad;
                CrossMTAdmob.Current.OnAppOpenFailedToShow += Current_OnAppOpenFailedToShow;
                CrossMTAdmob.Current.OnAppOpenImpression += Current_OnAppOpenImpression;
                CrossMTAdmob.Current.OnAppOpenClicked += Current_OnAppOpenClicked;
                CrossMTAdmob.Current.OnMobileAdsInitialized += Current_OnMobileAdsInitialized;
            }
        }

        private void Current_OnInterstitialImpression(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Interstitial Impression" });
            Debug.WriteLine("OnInterstitialImpression");
        }

        private void Current_OnInterstitialFailedToShow(object sender, MTEventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Interstitial Failed to show" });
            Debug.WriteLine($"OnInterstitialFailedToShow: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void Current_OnInterstitialFailedToLoad(object sender, MTEventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Interstitial failed to load" });
            Debug.WriteLine($"OnInterstitialFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void Current_OnInterstitialClicked(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Interstitial clicked" });
            Debug.WriteLine("OnInterstitialClicked");
        }

        private void Current_OnInterstitialClosed(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Interstitial closed" });
            Debug.WriteLine("OnInterstitialClosed");
        }

        private void Current_OnInterstitialOpened(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Interstitial opened" });
            Debug.WriteLine("OnInterstitialOpened");
        }

        private void Current_OnInterstitialLoaded(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Interstitial loaded" });
            Debug.WriteLine("OnInterstitialLoaded");
        }

        private void Current_OnRewardedClicked(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Reward Clicked" });
            Debug.WriteLine("OnRewardedClicked");
        }

        private void Current_OnRewardedImpression(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Rewarded Impression" });
            Debug.WriteLine("OnRewardedImpression");
        }

        private void Current_OnRewardedVideoAdOpened(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Rewarded Video Ad Opened" });
            Debug.WriteLine("OnRewardedVideoAdOpened");
        }

        private void Current_OnRewardedVideoAdLoaded(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Rewarded Video Ad Loaded" });
            Debug.WriteLine("OnRewardedVideoAdLoaded");
        }

        private void Current_OnRewardedVideoAdFailedToLoad(object sender, MTEventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Rewarded Video Ad Failed to Load" });
            Debug.WriteLine($"OnRewardedVideoAdFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
        }
        private void Current_OnRewardedFailedToShow(object sender, MTEventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Rewarded  Failed to Show" });
            Debug.WriteLine($"OnRewardedFailedToShow: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void Current_OnRewardedVideoAdClosed(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Rewarded Video Ad Closed" });
            Debug.WriteLine("OnRewardedVideoAdClosed");
        }

        private void Current_OnRewarded(object sender, MTEventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Rewarded" });
            Debug.WriteLine($"OnRewarded: {e.RewardType} - {e.RewardAmount}");
        }

        private void MyAds_AdVOpened(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "Banner opened" });
            Console.WriteLine("MyAds_AdVOpened");
        }

        private void MyAds_AdVImpression(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "Banner impression" });
            Console.WriteLine("MyAds_AdVImpression");
        }

        private void MyAds_AdVClosed(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "Banner closed" });
            Console.WriteLine("MyAds_AdVClosed");
        }

        private void MyAds_AdsClicked(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "Banner clicked" });
            Console.WriteLine("MyAds_AdsClicked");
        }

        private void MyAds_AdFailedToLoad(object sender, MTEventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "Banner failed to load" });
            Debug.WriteLine($"MyAds_AdFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void MyAds_AdLoaded(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "Banner loaded" });
            Console.WriteLine("MyAds_AdLoaded");
        }

        private void LoadReward_OnClicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadRewarded("ca-app-pub-3940256099942544/5224354917");
        }

        private void ShowReward_OnClicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowRewarded();
        }

        private void IsRewardLoaded_OnClicked(object sender, EventArgs e)
        {
            myLabel.Text = CrossMTAdmob.Current.IsRewardedLoaded().ToString();
        }

        private void LoadRewardInterstitial_OnClicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadRewardedInterstitial("ca-app-pub-3940256099942544/5354046379");
        }

        private void ShowRewardInterstitial_OnClicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowRewardedInterstitial();
        }

        private void IsRewardInterstitialLoaded_OnClicked(object sender, EventArgs e)
        {
            myLabel.Text = CrossMTAdmob.Current.IsRewardedInterstitialLoaded().ToString();
        }

        private void EmptyRewardedInterstitialList(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.EmptyRewardInterstitialAdsList();
        }

        private void GetNumOfLoadedRewardedInterstitial(object sender, EventArgs e)
        {
            myLabel.Text = "Loaded Rewarded Interstitial: " + CrossMTAdmob.Current.GetNumberOfRewarededInterstitialsLoaded().ToString();
        }

        private void LoadInterstitial_OnClicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/1033173712");
        }

        private void ShowInterstitial_OnClicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowInterstitial();
        }

        private void IsLoadedInterstitial_OnClicked(object sender, EventArgs e)
        {
            myLabel.Text = CrossMTAdmob.Current.IsInterstitialLoaded().ToString();
        }

        private void NextPage(object sender, EventArgs e)
        {
            DisableEvents();
            Navigation.PushAsync(new SecondPage());
        }

        private void DisableEvents()
        {
            _shouldSetEvents = true;
            CrossMTAdmob.Current.OnUserEarnedReward -= Current_OnRewarded;
            CrossMTAdmob.Current.OnRewardedClosed -= Current_OnRewardedVideoAdClosed;
            CrossMTAdmob.Current.OnRewardedFailedToLoad -= Current_OnRewardedVideoAdFailedToLoad;
            CrossMTAdmob.Current.OnRewardedFailedToShow -= Current_OnRewardedFailedToShow;
            CrossMTAdmob.Current.OnRewardedLoaded -= Current_OnRewardedVideoAdLoaded;
            CrossMTAdmob.Current.OnRewardedOpened -= Current_OnRewardedVideoAdOpened;
            CrossMTAdmob.Current.OnRewardedImpression -= Current_OnRewardedImpression;
            CrossMTAdmob.Current.OnRewardedClicked -= Current_OnRewardedClicked;

            CrossMTAdmob.Current.OnInterstitialLoaded -= Current_OnInterstitialLoaded;
            CrossMTAdmob.Current.OnInterstitialFailedToLoad -= Current_OnInterstitialFailedToLoad;
            CrossMTAdmob.Current.OnInterstitialOpened -= Current_OnInterstitialOpened;
            CrossMTAdmob.Current.OnInterstitialFailedToShow -= Current_OnInterstitialFailedToShow;
            CrossMTAdmob.Current.OnInterstitialClosed -= Current_OnInterstitialClosed;
            CrossMTAdmob.Current.OnInterstitialClicked -= Current_OnInterstitialClicked;
            CrossMTAdmob.Current.OnInterstitialImpression -= Current_OnInterstitialImpression;

            CrossMTAdmob.Current.OnAppOpenAdLoaded -= Current_OnAppOpenAdLoaded;
            CrossMTAdmob.Current.OnAppOpenOpened -= Current_OnAppOpenOpened;
            CrossMTAdmob.Current.OnAppOpenClosed -= Current_OnAppOpenClosed;
            CrossMTAdmob.Current.OnAppOpenFailedToLoad -= Current_OnAppOpenFailedToLoad;
            CrossMTAdmob.Current.OnAppOpenFailedToShow -= Current_OnAppOpenFailedToShow;
            CrossMTAdmob.Current.OnAppOpenImpression -= Current_OnAppOpenImpression;
            CrossMTAdmob.Current.OnAppOpenClicked -= Current_OnAppOpenClicked;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowPrivacyOptionsForm();
        }

        private void ResetForm(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.Reset();
        }

        private void CheckConsent(object sender, EventArgs e)
        {
            var consent = CrossMTAdmob.Current.GetConsentStatus();
            MyStack.Children.Add(new Label { Text = $"Consent: {consent}" });
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var canShow = CrossMTAdmob.Current.CanShowPersonalisedAds();
            MyStack.Children.Add(new Label { Text = $"Pers. Ads: {canShow}" });
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var canShow = CrossMTAdmob.Current.CanShowNonPersonalisedAds();
            MyStack.Children.Add(new Label { Text = $"Non Pers. Ads: {canShow}" });
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            var canShow = CrossMTAdmob.Current.CanShowLimitedAds();
            MyStack.Children.Add(new Label { Text = $"Limited Ads: {canShow}" });
        }

        private void Current_OnAppOpenAdLoaded(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Ad Loaded" });
            Debug.WriteLine("OnAppOpenAdLoaded");
        }

        private void Current_OnAppOpenOpened(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Opened" });
            Debug.WriteLine("OnAppOpenOpened");
        }

        private void Current_OnAppOpenClosed(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Closed" });
            Debug.WriteLine("OnAppOpenClosed");
        }

        private void Current_OnAppOpenFailedToLoad(object sender, MTEventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Failed To Load" });
            Debug.WriteLine($"Current_OnAppOpenFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void Current_OnAppOpenFailedToShow(object sender, MTEventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Failed To Show" });
            Console.WriteLine($"Current_OnAppOpenFailedToShow: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void Current_OnAppOpenImpression(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Impression" });
            Debug.WriteLine("Current_OnAppOpenImpression");
        }

        private void Current_OnAppOpenClicked(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Clicked" });
            Debug.WriteLine("Current_OnAppOpenClicked");
        }

        private void Current_OnMobileAdsInitialized(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On Mobile Ads Initialized" });
            Debug.WriteLine("Current_OnMobileAdsInitialized");
        }

        private void LoadBanner(object sender, EventArgs e)
        {
            myAds.LoadAd();
        }

        private void ClearEvents(object sender, EventArgs e)
        {
            MyStack.Children.Clear();
        }

        private void GetNumOfLoadedInterstitials(object sender, EventArgs e)
        {
            myLabel.Text = "Loaded Interstitials: " + CrossMTAdmob.Current.GetNumberOfInterstitialsLoaded().ToString();
        }

        private void EmptyInterstitialList(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.EmptyInterstitialAdsList();
        }

        private void GetNumOfLoadedRewarded(object sender, EventArgs e)
        {
            myLabel.Text = "Loaded Rewarded: " + CrossMTAdmob.Current.GetNumberOfRewarededLoaded().ToString();
        }

        private void EmptyRewardedList(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.EmptyRewardedAdsList();
        }

        private void IsRewardLoadedInterstitial_OnClicked(object sender, EventArgs e)
        {
            myLabel.Text = "Rewarded Interstitial loaded: " + CrossMTAdmob.Current.IsRewardedInterstitialLoaded().ToString();
        }
    }
}
