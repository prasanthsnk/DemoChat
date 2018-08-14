using DemoChat.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoChat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SlidingPage : ContentPage, ISwipeCallBack
    {
        public SlidingPage()
        {
            InitializeComponent();
            //  PageDown.TranslationY = 1000;
            SwipeListener swipeListener = new SwipeListener(Page, this);
        }

        public void onBottomSwipe(View view, double translatedX, double translatedY)
        {
            System.Diagnostics.Debug.WriteLine("Swiped");
            DownWhite_Tapped(null, null,translatedX,translatedY);
        }

        public void onLeftSwipe(View view, double translatedX, double translatedY)
        {
            System.Diagnostics.Debug.WriteLine("Swiped");
        }

        public void onNothingSwiped(View view, double translatedX, double translatedY)
        {
            System.Diagnostics.Debug.WriteLine("Swiped");
        }

        public void onRightSwipe(View view, double translatedX, double translatedY)
        {
            System.Diagnostics.Debug.WriteLine("Swiped");
        }

        public void onTopSwipe(View view, double translatedX, double translatedY)
        {
            System.Diagnostics.Debug.WriteLine("Swiped");
            UpBlue_Tapped(null, null, translatedX, translatedY);
        }

        async void UpBlue_Tapped(object sender, System.EventArgs e, double translatedX, double translatedY)
        {
            await PageDown.TranslateTo(0, Page.Height/2, 500, Easing.SinOut);
        }

        async void DownWhite_Tapped(object sender, System.EventArgs e, double translatedX, double translatedY)
        {
            await PageDown.TranslateTo(0, Page.Height, 500, Easing.SinOut);
        }
    }
}