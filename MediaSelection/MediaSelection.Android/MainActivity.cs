using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.OS;
using MediaSelection.Droid.Service;
using MediaSelection.Service;
using Prism;
using Prism.Ioc;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MediaSelection.Droid
{
    [Activity(Label = "MediaSelection", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static readonly int PickImageId = 1000;
        internal static MainActivity Instance { get; private set; }
        public TaskCompletionSource<Stream> PickImageTaskCompletionSource { set; get; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            MessagingCenter.Subscribe<string>(this, "w", (arg) =>
            {
                //Test Logic
            });
            //Set the current activity instance for later use.
            Instance = this;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }

        /// <summary>
        /// This is over-ridable method to get the result.
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="resultCode"></param>
        /// <param name="intent"></param>
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);

            if (requestCode == PickImageId)
            {
                if ((resultCode == Result.Ok) && (intent != null))
                {
                    var uri = intent.Data;
                    Stream stream = ContentResolver.OpenInputStream(uri);
                    PickImageTaskCompletionSource.SetResult(stream); //Here we are getting selected image/video in stream form.
                }
                else
                {
                    PickImageTaskCompletionSource.SetResult(null); // Need to validate end result.
                }
            }
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
            container.Register<IPicturePicker, PicturePickerImplementation>();
        }
    }
}

