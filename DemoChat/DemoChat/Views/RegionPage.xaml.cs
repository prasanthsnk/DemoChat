using DemoChat.Models;
using DemoChat.ViewModels;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoChat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegionPage : ContentPage
    {
        private RegionViewModel RegionViewModel;
        

        public RegionPage()
        {
            InitializeComponent();
            RegionViewModel = new RegionViewModel();
            InitRegion();
            this.BindingContext = RegionViewModel;
        }
       private void InitRegion() {
            ObservableCollection<RegionModel> regionList = new ObservableCollection<RegionModel>
            {
                new RegionModel("Region 1"),
                new RegionModel("Region 2")
            };
            RegionViewModel.RegionList = regionList;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitRegion();
        }
        public void UpdateUiAsync() {
            InitRegion();
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is RegionModel item)
            {
                //Navigation.PushAsync(new ChatPage(item.Name));
                Navigation.PushAsync(new ChatPage());
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}