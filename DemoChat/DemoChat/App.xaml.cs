using DemoChat.Common;
using DemoChat.Data;
using DemoChat.Models;
using DemoChat.Views;
using Plugin.FirebasePushNotification;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DemoChat
{
    public partial class App : Application
    {
        static ChatItemDatabase database;
        public App()
        {
            InitializeComponent();
            // MainPage = new NavigationPage(new RegionPage());
            // MainPage = new NavigationPage(new DashboardPage());

            //DashboardPage dashboardPage = new DashboardPage();
            //NavigationPage.SetHasNavigationBar(dashboardPage, false);
            //   Navigation.PushAsync(dashboardPage);
             MainPage = new DetailPage();
            // MainPage = new NavigationPage(new MasterTabbedPage());
            //MainPage = new NavigationPage(new DetailPage());
        } 

        protected override void OnStart()
        {
            // Handle when your app starts
            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"TOKEN REC: {p.Token}");
            };
            System.Diagnostics.Debug.WriteLine($"TOKEN: {CrossFirebasePushNotification.Current.Token}");

            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Received");
                System.Diagnostics.Debug.WriteLine($"{p.Data}");

                ChatModel someObject = ObjectExtensions.ToObject<ChatModel>(p.Data);
                SaveAsync(someObject);
            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                //System.Diagnostics.Debug.WriteLine(p.Identifier);

                System.Diagnostics.Debug.WriteLine("Opened");
                System.Diagnostics.Debug.WriteLine($"{p.Data}");
            };
            CrossFirebasePushNotification.Current.OnNotificationDeleted += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Dismissed");
            };
            
        }

        public static ChatItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ChatItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sqlite.db"));
                }
                return database;
            }
        }
        
        private async void SaveAsync(ChatModel msg)
        {
            var Chat = new ChatModel
            {
                Message = msg.body,
                Type = 2,
                body = msg.body,
                title = msg.title,
                ImageUrl = msg.ImageUrl,
                Region = msg.Region,
            };

            int id =   await App.Database.SaveItemAsync(Chat);
            var CurrentPage = (App.Current.MainPage as NavigationPage).CurrentPage;
           if ( CurrentPage is ChatPage)
            {
                (CurrentPage as ChatPage).UpdateUiAsync(Chat.ID);
            }
            else if (CurrentPage is RegionPage)
            {
                (CurrentPage as RegionPage).UpdateUiAsync();
            }
            else if (CurrentPage is DetailPage)
            {
                (CurrentPage as DetailPage).UpdateUiAsync(Chat.ID);
            }
        }

        //private async void initsave() {
        //    for (int i = 1; i < 15; i++) {
        //        var Chat = new ChatModel
        //        {
        //            Message = "Power mamagement high and its simply dummy test for list view for displaying motor details and power details for particular region",
        //            Type = 2,
        //            body ="message",
        //            title = "Motor "+i,
        //            ImageUrl = null,
        //            Region = "Region 1",
        //        };
        //        await App.Database.SaveItemAsync(Chat);
        //    }
        //}

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }


        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
