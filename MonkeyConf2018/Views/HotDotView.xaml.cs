namespace MonkeyConf2018.Views
{
    using MonkeyConf2018.ViewModels;
    using Xamarin.Forms;

    public partial class HotDotView : ContentPage
    {
        public HotDotView()
        {
            InitializeComponent();
            BindingContext = new HotDogViewModel();
        }
    }
}
