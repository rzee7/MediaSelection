using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaSelection.ViewModels
{
	public class WelcomPageViewModel : BindableBase
	{
        public WelcomPageViewModel()
        {

        }
        private string _orientation;
        public string Orientation
        {
            get { return _orientation; }
            set { SetProperty(ref _orientation, value); }
        }
    }
}
