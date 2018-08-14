using UIKit;
using DemoChat.iOS.CustomRenderers;
using DemoChat.Views.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using DemoChat.Models;

[assembly: ExportRenderer(typeof(MessageViewCell), typeof(MessageRenderer))]
namespace DemoChat.iOS.CustomRenderers
{
    public class MessageRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableView tv)
        {
            var textVm = item.BindingContext as ChatModel;
            if (textVm != null)
            {
                string text = textVm.ImageUrl!= null ? "<IOS client doesn't support image messages yet ;(>" : (textVm.Type ==1 ? "Me" : textVm.Message) + ": " + textVm.Message;
                var chatBubble = new ChatBubble(textVm.Type ==2, text);
                return chatBubble.GetCell(tv);
            }
            return base.GetCell(item, tv);
        }
    }
}