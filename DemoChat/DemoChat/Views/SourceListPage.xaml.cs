using DemoChat.Models;
using DemoChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoChat.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SourceListPage : ContentPage
	{
        ChatViewModel chatViewModel;
        public SourceListPage ()
		{
			InitializeComponent ();
            chatViewModel = new ChatViewModel("Region 2");
            LoadData();
            this.BindingContext = chatViewModel;
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
                Navigation.PushAsync(new MessageListPage());
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}