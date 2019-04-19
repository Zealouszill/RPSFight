using Xamarin.Forms;

namespace RPSFight
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.RoshamboVM;
        }
    }
}
