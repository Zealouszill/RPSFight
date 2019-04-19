namespace RPSFight.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new RPSFight.App());
        }
    }
}
