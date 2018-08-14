using System.Collections.ObjectModel;

namespace DemoChat.Models
{
    public class GroupedChatModel : ObservableCollection<ChatModel>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
    }
}