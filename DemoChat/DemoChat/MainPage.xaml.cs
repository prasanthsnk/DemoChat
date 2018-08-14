using DemoChat.Views;
using Xamarin.Forms;

namespace DemoChat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Navigation.PushAsync(new RegionPage());
           // App.Current.MainPage = new NavigationPage(new RegionPage());
            //App.Current.MainPage.Navigation.PushAsync(new RegionPage());

        }
    }
}
