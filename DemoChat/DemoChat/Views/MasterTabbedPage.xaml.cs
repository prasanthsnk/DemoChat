using DemoChat.Views.Controls;
using Xamarin.Forms.Xaml;

namespace DemoChat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterTabbedPage : TabbedSearchPage    

    {
      
        public MasterTabbedPage ()
        {
            InitializeComponent();
        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            this.Title = this.CurrentPage.Title;
        }
    }
}