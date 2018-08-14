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
        }
         
        public void UpdateUiAsync(int id)
        {
          
        }
    }
}