using System;
using System.Collections.Generic;
using System.Text;

namespace DemoChat.Models
{
    class RegionModel
    {
        public RegionModel()
        {
        }
        public RegionModel(String name)
        {
            this.Name = name;
            LoadCount();
        }
        private async void LoadCount()
        {
            List<ChatModel> model = await App.Database.GetCountNotDoneAsyncByRegion(Name);
            IsReadCount = model.Count > 0 ? model.Count + "" : "" ;
        }

        public string Name { get; set; }
        public string IsReadCount { get; set; }
    }
}
