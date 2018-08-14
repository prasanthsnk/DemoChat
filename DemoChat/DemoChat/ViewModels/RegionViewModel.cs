using DemoChat.Models;
using System.Collections.ObjectModel;

namespace DemoChat.ViewModels
{
    class RegionViewModel : BaseViewModel
    {
        private ObservableCollection<RegionModel> regionList;

        public RegionViewModel() { }

        public ObservableCollection<RegionModel> RegionList
        {
            get
            {
                return regionList;
            }
            set
            {
                if (value != null)
                {
                    regionList = value;
                    NotifyPropertyChanged("RegionList");
                }
            }
        }
        
    }
}
