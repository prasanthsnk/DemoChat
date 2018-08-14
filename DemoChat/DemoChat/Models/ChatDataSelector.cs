using Xamarin.Forms;

namespace DemoChat.Models
{

    public class ChatDataSelector : DataTemplateSelector
    {
        public DataTemplate ReceivedTemplate { get; set; }

        public DataTemplate SentTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((ChatModel)item).Type == 1 ? SentTemplate : ReceivedTemplate;
        }
    }
}

