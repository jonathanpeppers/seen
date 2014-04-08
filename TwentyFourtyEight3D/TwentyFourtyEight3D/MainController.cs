using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

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
