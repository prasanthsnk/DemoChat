using DemoChat.Models;
using DemoChat.ViewModels;
using DemoChat.Views.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace DemoChat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : SearchPage
    {
           
        ChatViewModel chatViewModel;
        string region;
        public ChatPage() {
            region = "Region 1";
            InitializeComponent();
            chatViewModel = new ChatViewModel(region);
            this.BindingContext = chatViewModel;
            LoadData();
        }
        //public ChatPage(string region)
        //{
        //    InitializeComponent();
        //    this.region = region;
        //    chatViewModel = new ChatViewModel(region);
        //    this.BindingContext = chatViewModel;
        //    LoadData();
        //}

        private async void UpdateIsRead() {
            int id = await App.Database.UpdateIsRead(region);
            System.Diagnostics.Debug.WriteLine($"id REC: {id}");
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Navigation.PushAsync(new MessageListPage());
                ((ListView)sender).SelectedItem = null;
            }
        }

        private async void LoadData()
        {
            List<ChatModel> ListChatsRead = await App.Database.GetItemsNotDoneAsyncByRegionAndIsRead(region, "1");
            List<ChatModel> ListChatsNotRead = await App.Database.GetItemsNotDoneAsyncByRegionAndIsRead(region, "0");

            ObservableCollection<GroupedChatModel> grouped = new ObservableCollection<GroupedChatModel>();

            if (ListChatsRead.Count > 0)
            {
                var ReadGroup = new GroupedChatModel() { LongName = "Messages", ShortName = "M" }; ;
                foreach (ChatModel chat in ListChatsRead)
                {
                    ReadGroup.Add(chat);
                }
                grouped.Add(ReadGroup);
            }

            if (ListChatsNotRead.Count > 0)
            {
                var UnReadGroup = new GroupedChatModel() { LongName = "Unread", ShortName = "U" };
                foreach (ChatModel chat in ListChatsNotRead)
                {
                    UnReadGroup.Add(chat);
                }
                grouped.Add(UnReadGroup);
            }
         
            chatViewModel.Grouped = grouped;

            if (ListChatsRead.Count > 0)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    chatList.ScrollTo(ListChatsRead[ListChatsRead.Count - 1], ScrollToPosition.End, true);
                });
            }
                UpdateIsRead();
        }

        public async  void UpdateUiAsync(int id)
        {
            if (chatViewModel != null)
            {
                ChatModel chat = await App.Database.GetItemAsync(id);
                if (chat.Region.Equals(region))
                {
                    chat.IsRead = 1;
                    chatList.ScrollTo(chat, ScrollToPosition.End, true);
                    await App.Database.SaveItemAsync(chat);
                    LoadData();
                }
            }
        }
    }
}