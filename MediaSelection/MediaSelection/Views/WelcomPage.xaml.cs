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
            MessagingCenter.Send<string>("w", AppOrientation.Landscape.ToString());
        }
    }
}
