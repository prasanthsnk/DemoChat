using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoChat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : TabbedPage
    {
        public DetailPage ()
        {
            InitializeComponent();
        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            this.Title = this.CurrentPage.Title;
            //switch (Title) {
            //    case "Home":
            //        (this.CurrentPage as SourceListPage).LoadSearch();
            //        break;
            //    case "Notification":
            //        (this.CurrentPage as MessageListPage).LoadSearch();
            //        break;
            //    case "Saved Messages":
            //        (this.CurrentPage as ChatPage).LoadSearch();
            //        break;
            //}
        }
         
        public void UpdateUiAsync(int id)
        {
          
        }
    }
}