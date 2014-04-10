using System;
using System.Drawing;
using System.Threading.Tasks;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ChartboostSDK;

namespace TwentyFourtyEight3D
{
    public partial class MainController : UIViewController
    {
        public MainController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _splash.BackgroundColor = UIColor.FromRGB(0xfa, 0xf8, 0xef);
            _webView.ShouldStartLoad = (webView, request, type) =>
            {
                string url = request.Url.ToString();
                bool isRestart = url.StartsWith("restart://");
                if (isRestart && _splash.Superview == null)
                    Chartboost.SharedChartboost.ShowInterstitial();
                return !isRestart;
            };
            _webView.LoadFinished += (sender, e) =>
            {
                UIView.Animate(.5, .75, UIViewAnimationOptions.CurveEaseInOut, () => _splash.Alpha = 0, () =>
                {
                    _splash.RemoveFromSuperview();
                    Chartboost.SharedChartboost.ShowInterstitial();
                });
            };
            _webView.LoadError += (sender, e) =>
            {
                Console.WriteLine("Error: " + e.Error.LocalizedDescription);
            };

            _webView.LoadRequest(NSUrlRequest.FromUrl(NSUrl.FromFilename("Html/demo-2048.html")));
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            return UIInterfaceOrientationMask.Landscape;
        }

        public override bool PrefersStatusBarHidden()
        {
            return true;
        }

        public override UIViewController ChildViewControllerForStatusBarStyle()
        {
            return null;
        }
    }
}
