using MediaSelection.Enums;
using Xamarin.Forms;

namespace MediaSelection.Views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //We are unlocking an orientation for other pages.
            MessagingCenter.Send<string>(AppOrientation.Landscape.ToString(), "mode");
        }
    }
}
