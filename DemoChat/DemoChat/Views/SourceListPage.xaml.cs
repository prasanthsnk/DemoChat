using DemoChat.Models;
using DemoChat.ViewModels;
using DemoChat.Views.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoChat.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SourceListPage : SearchPage
	{
        ChatViewModel chatViewModel;
        public SourceListPage ()
		{
			InitializeComponent ();
            chatViewModel = new ChatViewModel("Region 2");
            LoadData();
            this.BindingContext = chatViewModel;
            LoadSearch();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
           // LoadSearch();
        }
        public async void LoadSearch()
        {
            await Task.Delay(1500);
            ShowSearch = "Show";
        }
        private async void LoadData()
        {
            List<ChatModel> listchats = await App.Database.GetItemsNotDoneAsync();
            chatViewModel.ChatList = new ObservableCollection<ChatModel>(listchats);
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                //Navigation.PushAsync(new MessageListPage());
                Navigation.PushAsync(new ChatPage());
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}