﻿using MediaSelection.Service;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MediaSelection.Enums;

namespace MediaSelection.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        IPicturePicker picturePicker;
        public MainPageViewModel(INavigationService navigationService, IPicturePicker picturePicker)
            : base(navigationService)
        {
            this.picturePicker = picturePicker;
            Title = "Main Page";
        }
        private ImageSource _selectedImage;
        public ImageSource SelectedImage
        {
            get { return _selectedImage; }
            set { SetProperty(ref _selectedImage, value); }
        }
        private DelegateCommand _selectMedia;
        public DelegateCommand SelectMedia =>
            _selectMedia ?? (_selectMedia = new DelegateCommand(async () => { await ExecuteSelectMedia(); }));

        async Task ExecuteSelectMedia()
        {
            var stream = await picturePicker.GetImageStreamAsync();
            SelectedImage = ImageSource.FromStream(() => stream); //I'm just reading Image, We might have video as well, need to check.

            //These commented lines applied portrait lock on the NextPage, Here on WelcomePage.

            //MessagingCenter.Send<string>(AppOrientation.Portrait.ToString(), "mode");
            //await NavigationService.NavigateAsync("WelcomePage");

        }
    }
}
