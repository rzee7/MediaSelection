using Foundation;
using MediaSelection.iOS.Service;
using Prism;
using Prism.Ioc;
using UIKit;
using MediaSelection.Service;
using ObjCRuntime;
using Xamarin.Forms;

namespace MediaSelection.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        bool disableAllOrientation = false;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(new iOSInitializer()));


            MessagingCenter.Subscribe<string>(this, "w", (arg) =>
            {
                disableAllOrientation = true;
            });
            return base.FinishedLaunching(app, options);
        }
        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, [Transient] UIWindow forWindow)
        {
            if (disableAllOrientation == true)
            {
                return UIInterfaceOrientationMask.Portrait;
            }
            return UIInterfaceOrientationMask.All;
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            container.Register<IPicturePicker, PicturePickerImplementation>();
        }
    }
}
