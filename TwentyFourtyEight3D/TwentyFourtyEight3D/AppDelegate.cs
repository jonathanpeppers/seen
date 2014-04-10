using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ChartboostSDK;

namespace TwentyFourtyEight3D
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override void OnActivated(UIApplication application)
        {
            var cb = Chartboost.SharedChartboost;
            cb.AppId = "5345fc8389b0bb03bd2f5a5a";
            cb.AppSignature = "d9023ad1285ff29b4a7e7c9e68d3a4bb400008ca";
            cb.Delegate = new AdDelegate();
            cb.StartSession();
            cb.CacheInterstitial();
        }

        private class AdDelegate : ChartboostDelegate
        {
            public override void DidCacheInterstitial(string location)
            {
                Console.WriteLine("Cached Chartboost!");
            }

            public override void DidFailToLoadInterstitial(string location)
            {
                Console.WriteLine("Failed to load Chartboost!");
            }

            public override bool ShouldDisplayInterstitial(string location)
            {
                return true;
            }

            public override bool ShouldRequestInterstitial(string location)
            {
                return true;
            }

            public override void DidDismissInterstitial(string location)
            {
                Chartboost.SharedChartboost.CacheInterstitial(location);
            }

            public override bool ShouldRequestInterstitialsInFirstSession
            {
                get { return false; }
            }
        }
    }
}

