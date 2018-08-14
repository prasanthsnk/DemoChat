using DemoChat.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoChat.ViewModels
{
    class ChatViewModel : BaseViewModel
    {
        private string region;
        public ChatViewModel(string region) {
            this.region = region;
            //LoadData();
            OnClickMessageSend = new Command(() => {
                SendMsg();
            });
        }
        //private async void LoadData() {
        //    List<ChatModel> ListChats = await App.Database.GetItemsNotDoneAsyncByRegion(region);
        //    ChatList = new ObservableCollection<ChatModel>(ListChats);

        //    List<ChatModel> ListChatsRead = await App.Database.GetItemsNotDoneAsyncByRegionAndIsRead(region, "1");
        //    //ObservableCollection<ChatModel> ReadList = new ObservableCollection<ChatModel>(ListChatsRead as List<ChatModel>);
        //    //GroupedChatModel chatModelRead = new GroupedChatModel
        //    //{
        //    //    LongName = "Read",
        //    //    ShortName = "Read"
        //    //};


        //    List<ChatModel> ListChatsNotRead = await App.Database.GetItemsNotDoneAsyncByRegionAndIsRead(region, "0");
        //    //ObservableCollection<ChatModel> UnReadList = new ObservableCollection<ChatModel>(ListChatsRead as List<ChatModel>);
        //    //GroupedChatModel chatModelUnRead = (UnReadList as GroupedChatModel);
        //    //chatModelUnRead.LongName = "UnRead";
        //    //chatModelUnRead.ShortName = "UnRead";

        //    var ReadGroup = new GroupedChatModel() { LongName = "Read", ShortName = "R"  };
        //    foreach (ChatModel chat in ListChatsRead ){
        //        ReadGroup.Add(chat);
        //    }

        //    var UnReadGroup = new GroupedChatModel() { LongName = "Unread", ShortName = "U" };
        //    foreach (ChatModel chat in ListChatsNotRead)
        //    {
        //        UnReadGroup.Add(chat);
        //    }

        //    ObservableCollection<GroupedChatModel> grouped = new ObservableCollection<GroupedChatModel>
        //    {
        //        ReadGroup,
        //        UnReadGroup
        //    };
        //    Grouped = grouped;
        //}
        private async void SendMsg() {
            var Chat = new ChatModel
            {
                Message = MessageSend,
                Type = 1,
                Region = region
            };
            await App.Database.SaveItemAsync(Chat);
            ChatList.Add(Chat);
            MessageSend = null;
        }
        private ObservableCollection<ChatModel> chatList;

        public ObservableCollection<ChatModel> ChatList
        {
            get
            {
                return this.chatList;
            }
            set
            {
                if (value != null)
                {
                    this.chatList = value;
                    NotifyPropertyChanged("ChatList");
                }
            }
        }
        private string message;

        public string MessageSend
        {
            get { return message; }
            set
            {
                message = value;
                NotifyPropertyChanged("MessageSend");
            }
        }
        public ICommand OnClickMessageSend { get; set; }

      
        private ObservableCollection<GroupedChatModel> grouped;
        public ObservableCollection<GroupedChatModel> Grouped {
            get { return grouped; }
            set
            {
                grouped = value;
                NotifyPropertyChanged("Grouped");
            }
        }
    }
}
