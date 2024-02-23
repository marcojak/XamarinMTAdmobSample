using System;
using System.Collections.Generic;
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
            CrossMTAdmob.Current.TestDevices = new List<string>() { "D70290758AB9D6060C3B14AA41DAB53A", "0EB3E09F26C31286957EF0BF27B58A4E" };

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
                CrossMTAdmob.Current.OnAppOpenFailedToLoad += Current_OnAppOpenAdFailedToLoad;
                CrossMTAdmob.Current.OnAppOpenOpened += Current_OnAppOpenAdOpened;
                CrossMTAdmob.Current.OnAppOpenFailedToShow += Current_OnAppOpenAdFailedToShow;
                CrossMTAdmob.Current.OnAppOpenClosed += Current_OnAppOpenAdClosed;
                CrossMTAdmob.Current.OnAppOpenClicked += Current_OnAppOpenAdClicked;
                CrossMTAdmob.Current.OnAppOpenImpression += Current_OnAppOpenAdImpression;
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
            CrossMTAdmob.Current.OnAppOpenFailedToLoad -= Current_OnAppOpenAdFailedToLoad;
            CrossMTAdmob.Current.OnAppOpenOpened -= Current_OnAppOpenAdOpened;
            CrossMTAdmob.Current.OnAppOpenFailedToShow -= Current_OnAppOpenAdFailedToShow;
            CrossMTAdmob.Current.OnAppOpenClosed -= Current_OnAppOpenAdClosed;
            CrossMTAdmob.Current.OnAppOpenClicked -= Current_OnAppOpenAdClicked;
            CrossMTAdmob.Current.OnAppOpenImpression -= Current_OnAppOpenAdImpression;
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

        private void LoadBanner(object sender, EventArgs e)
        {
            myAds.LoadAd();
        }

        private void ClearEvents(object sender, EventArgs e)
        {
            MyStack.Children.Clear();
        }
        private void Current_OnAppOpenAdImpression(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Ad Impression" });
            Debug.WriteLine("OnAppOpenAdImpression");
        }

        private void Current_OnAppOpenAdClicked(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Ad Clicked" });
            Debug.WriteLine("OnAppOpenAdClicked");
        }

        private void Current_OnAppOpenAdClosed(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Ad Closed" });
            Debug.WriteLine("OnAppOpenAdClosed");
        }

        private void Current_OnAppOpenAdFailedToShow(object sender, MTEventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Ad Failed to Show" });
            Debug.WriteLine($"OnAppOpenAdFailedToShow: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void Current_OnAppOpenAdOpened(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Ad Opened" });
            Debug.WriteLine("OnAppOpenAdOpened");
        }

        private void Current_OnAppOpenAdFailedToLoad(object sender, MTEventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Ad Failed to Load" });
            Debug.WriteLine($"OnAppOpenAdFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void Current_OnAppOpenAdLoaded(object sender, EventArgs e)
        {
            MyStack.Children.Add(new Label { Text = "On App Open Ad Loaded" });
            Debug.WriteLine("OnAppOpenAdLoaded");
        }
    }
}
