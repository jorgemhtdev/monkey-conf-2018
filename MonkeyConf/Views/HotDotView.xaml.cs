using System;
using System.Collections.Generic;
using MonkeyConf.ViewModels;
using Xamarin.Forms;

namespace MonkeyConf.Views
{
    public partial class HotDotView : ContentPage
    {
        public HotDotView()
        {
            InitializeComponent();

            BindingContext = new HotDogViewModel();
        }
    }
}
