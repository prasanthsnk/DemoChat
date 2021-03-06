﻿using DemoChat.Models;
using DemoChat.ViewModels;
using DemoChat.Views.Controls;
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
	public partial class MessageListPage : SearchPage
	{
        ChatViewModel chatViewModel;

        public MessageListPage ()
		{
			InitializeComponent ();
             chatViewModel = new ChatViewModel("Region 1");
            LoadData();
            this.BindingContext = chatViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
          //  LoadSearch();
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
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}